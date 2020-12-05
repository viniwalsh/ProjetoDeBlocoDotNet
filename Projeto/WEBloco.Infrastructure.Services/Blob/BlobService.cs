using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Threading.Tasks;
using WEBloco.Domain.Model.Interfaces;

namespace WEBloco.Infrastructure.Services.Blob
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private const string _container = "imagensheroi";

        public BlobService(string storageAccount)
        {
            _blobServiceClient = new BlobServiceClient(storageAccount);
        }

        public async Task<string> UploadAsync(Stream stream)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_container);

            if (!await containerClient.ExistsAsync())
            {
                await containerClient.CreateIfNotExistsAsync();
                await containerClient.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
            }

            var blobClient = containerClient.GetBlobClient($"{Guid.NewGuid()}.jpg");
            
            await blobClient.UploadAsync(stream, true);

            return blobClient.Uri.ToString();
        }

    }
}
