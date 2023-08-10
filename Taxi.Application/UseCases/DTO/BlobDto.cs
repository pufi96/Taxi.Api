using System.IO;

namespace Taxi.Application.UseCases.DTO
{
    public class BlobDto
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public Stream Content { get; set; }
    }
    
    public class BlobFileDto
    {
        public string BlobLocation { get; set; }
        public string BlobSasToken { get; set; }
        public double FileSize { get; set; }
    }
}
