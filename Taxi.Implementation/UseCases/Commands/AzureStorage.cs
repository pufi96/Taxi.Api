using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries;

namespace Taxi.Implementation.UseCases.Commands
{
    public class AzureStorage : IAzureStorage
    {
        private readonly string _storageConnectionString;
        private readonly string _storageContainerName;
        private readonly ILogger<AzureStorage> _logger;

        public AzureStorage(IConfiguration configuration, ILogger<AzureStorage> logger)
        {
            _storageConnectionString = configuration.GetConnectionString("BlobConnectionString");
            _storageContainerName = configuration.GetConnectionString("BlobContainerName");
            _logger = logger;
        }

        public async Task<BlobResponseDto> DeleteAsync(string blobFilename)
        {
            BlobContainerClient client = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            BlobClient file = client.GetBlobClient(blobFilename);

            try
            {
                await file.DeleteAsync();
            }
            catch(RequestFailedException ex)
                when(ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                _logger.LogError($"File {blobFilename} was not found.");
                return new BlobResponseDto
                {
                    Error = true,
                    Status = $"File with name {blobFilename} not found."
                };
            }
            return new BlobResponseDto
            {
                Error = false,
                Status = $"File: {blobFilename} has been successfully deleted."
            };
        }

        public async Task<BlobDto> DownloadAsync(string blobFileName)
        {
            BlobContainerClient client = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            try
            {
                BlobClient file = client.GetBlobClient(blobFileName);
                if (await file.ExistsAsync())
                {
                    var data = await file.OpenReadAsync();
                    Stream blobContent = data;

                    var content = await file.DownloadContentAsync();

                    string name = blobFileName;
                    string contenType = content.Value.Details.ContentType;

                    return new BlobDto
                    {
                        Content = blobContent,
                        Name = name,
                        ContentType = contenType
                    };
                }
            }
            catch(RequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                _logger.LogError($"File {blobFileName} was not found.");
            }
            return null;
        }

        public async Task<List<BlobDto>> ListAsync()
        {
            BlobContainerClient container = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            List<BlobDto> files = new List<BlobDto>();

            await foreach (BlobItem file in container.GetBlobsAsync())
            {
                string uri = container.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobDto
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = file.Properties.ContentType
                });
            }
            return files;
        }

        public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
        {
            BlobResponseDto response = new();

            BlobContainerClient container = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            BlobHttpHeaders blobHttpHeaders = new BlobHttpHeaders
            {
                ContentType = blob.ContentType
            };

            var guid = Guid.NewGuid();
            string fileName = guid + blob.FileName;
            
            try
            {
                BlobClient client = container.GetBlobClient(fileName);

                await using (Stream? data = blob.OpenReadStream())
                {
                    await client.UploadAsync(data, httpHeaders: blobHttpHeaders);
                }

                response.Status = $"File {fileName} uploaded successfully";
                response.Error = false;
                response.Blob.Uri = client.Uri.AbsoluteUri;
                response.Blob.Name = client.Name;
            }
            catch (RequestFailedException ex)
                when(ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
            {
                _logger.LogError($"File with name {fileName} already exists in container. Set another name to store the file in the container: '{_storageContainerName}.'");
                response.Status = $"File with name {fileName} already exists. Please use another name to store your file.";
                response.Error = true;
                return response;

            }
            catch(RequestFailedException ex)
            {
                // Log error to console and create a new response we can return to the requesting method
                _logger.LogError($"Unhandled Exception. ID: {ex.StackTrace} - Message: {ex.Message}");
                response.Status = $"Unexpected error: {ex.StackTrace}. Check log with StackTrace ID.";
                response.Error = true;
                return response;
            }

            return response;
        }
        public async Task<BlobFileDto> GetFileFromBlobStorage(string fileName)
        {
            BlobContainerClient container = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            var sasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = container.Name,
                ExpiresOn = DateTimeOffset.UtcNow.AddYears(1),
                Resource = "c",
            };

            sasBuilder.SetPermissions(BlobContainerSasPermissions.Read | BlobContainerSasPermissions.Write);
            var sasUri = container.GenerateSasUri(sasBuilder);

            float fileSize = 0;

            var blobClient = container.GetBlobClient(fileName);

            if (await blobClient.ExistsAsync())
            {
                BlobProperties properties = await blobClient.GetPropertiesAsync();
                fileSize = properties.ContentLength;
            }

            return await Task.FromResult<BlobFileDto>(new BlobFileDto()
            {
                BlobLocation = container.Uri.ToString().Replace(" ", "%20") + "/" + fileName,
                BlobSasToken = sasUri.Query,
                FileSize = fileSize
            });
        }

    }
}
