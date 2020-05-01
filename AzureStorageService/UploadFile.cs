using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AzureStorageService
{
    class UploadFile
    {
        private string _storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=mitaisdevstorage;AccountKey=CZD/Dd5OVbZaoZ+VCc0AY7XME+uOJuA1mB3RSdB23dKnriX/8WIyOLJqKn6PEHlYvcUo1gtx8waUEXuK97lhBA==;EndpointSuffix=core.windows.net";
        private CloudStorageAccount _cloudStorageAccount = null;
        private CloudBlobContainer _cloudBlobContainer = null;
        public bool UploadFileWithFileStream(FileStream fileStream)
        {
            string containerName = "mitais";

            //// Reference URL : https://mitaisdevstorage.blob.core.windows.net/mitais/someFileName.txt
            ///Global URL: https://mitaisdevstorage.blob.core.windows.net/
            ///Folder URL: /mitais/
            ///File Name: someFileName.txt
            if (CloudStorageAccount.TryParse(_storageConnectionString, out _cloudStorageAccount))
            {
                try
                {
                    CloudBlobClient cloudBlobClient = _cloudStorageAccount.CreateCloudBlobClient();
                    _cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
                    CloudBlobContainer blobContainer = cloudBlobClient.GetContainerReference(_cloudBlobContainer.Name);
                    blobContainer.CreateIfNotExistsAsync();

                    // Set the permissions so the blobs are public.  
                    BlobContainerPermissions permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    };

                    //Get the file details as dynamic
                    String fileName = "someFileName.txt";
                    CloudBlockBlob blockBlob = _cloudBlobContainer.GetBlockBlobReference(fileName);
                    blockBlob.UploadFromStreamAsync(fileStream);
                    return true;
                }
                catch
                {
                    return false;
                    //throw new Exception("File not uploaded");
                }
            }
            return false;


        }
    }
}
