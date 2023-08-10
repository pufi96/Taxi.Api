using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;

namespace Taxi.Application.UseCases.Queries
{
    public interface IAzureStorage
    {
        /// <summary>
        /// This method uploads a file submitted with the request
        /// </summary>
        /// <param name="file">File for upload</param>
        /// <returns>Blob with status</returns>
        Task<BlobResponseDto> UploadAsync(IFormFile file);

        /// <summary>
        /// This method downloads a file with the specified filename
        /// </summary>
        /// <param name="blobFileName">Filename</param>
        /// <returns>Blob</returns>
        Task<BlobDto> DownloadAsync(string blobFileName);

        /// <summary>
        /// This method deleted a file with the specified filename
        /// </summary>
        /// <param name="blobFileName">Filename</param>
        /// <returns>Blob with status</returns>
        Task<BlobResponseDto> DeleteAsync(string blobFileName);

        /// <summary>
        /// This method returns a list of all files located in the container
        /// </summary>
        /// <returns>Blobs in a list</returns>
        Task<List<BlobDto>> ListAsync();

        /// <summary>
        /// This method returns a requested file located in the container
        /// </summary>
        /// <returns>Blobs string location</returns>
        Task<BlobFileDto> GetFileFromBlobStorage(string fileName);
    }
}
