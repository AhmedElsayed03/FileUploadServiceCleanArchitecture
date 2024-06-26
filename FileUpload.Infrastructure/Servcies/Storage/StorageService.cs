using Microsoft.AspNetCore.Http;
using FileUpload.Application.Abstractions.Services.Storage;
using FileUpload.Application.Models.DTOs.Files;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FileUpload.Infrastructure.InfrastractureConstants.AppSettings;
using Oci.ObjectstorageService;
using Oci.Common.Auth;
using Oci.ObjectstorageService.Requests;
using Oci.ObjectstorageService.Responses;


namespace FileUpload.Infrastructure.Servcies.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ObjectStorageClient _objectStorageClient;
        private readonly string _namespaceName;
        private readonly string _bucketName;

        public StorageService(IConfiguration configuration,
            IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;

            var provider = new ConfigFileAuthenticationDetailsProvider("path_to_your_oci_config", "DEFAULT");
            _objectStorageClient = new ObjectStorageClient(provider);
            _bucketName = configuration.GetValue<string>("OCIBucketName");
            _namespaceName = configuration.GetValue<string>("OCINamespaceName");
        }


        #region Store files to OCI

        public async Task<string> UploadFileAsyncOCI(Stream file, string fileName)
        {
            await SaveFileToOCI(file, fileName);
            string url = GetFileUrlOCI(fileName);
            return url;
        }

        private async Task SaveFileToOCI(Stream file, string fileName)
        {
            var putObjectRequest = new PutObjectRequest
            {
                NamespaceName = _namespaceName,
                BucketName = _bucketName,
                ObjectName = fileName,
                PutObjectBody = file,
            };

            PutObjectResponse response = await _objectStorageClient.PutObject(putObjectRequest);
        }

        private string GetFileUrlOCI(string fileName)
        {
            var httpRequest = _contextAccessor.HttpContext!.Request;
            var builder = new UriBuilder()
            {
                Scheme = httpRequest.Scheme,
                Host = httpRequest.Host.Host,
                Port = httpRequest.Host.Port ?? default,
                Path = Path.Combine("oci/bucket/path", fileName), // Modify as per your OCI bucket path structure
            };

            var url = builder.ToString();
            return url;
        }

        #endregion









        #region Store files locally


        public async Task<string> UploadFileAsync(Stream file, string fileName)
        {
            await SaveFileToFolder(file, fileName);
            string url = GetFileUrl(fileName);
            return url;
        }

        private async Task SaveFileToFolder(Stream file, string fileName)
        {
            var folderPath = _configuration.GetValue<string>(StoragePath)!;    //"StoragePath": "./UploadedFiles"
            string filePath = Path.Combine(folderPath, fileName);              //./UploadedFiles/Guid.NewGuid();
            using var fileStream = new FileStream(filePath, FileMode.Create);  //Create File in this path
            await file.CopyToAsync(fileStream);                                //Copy file to the created stream
        }


        private string GetFileUrl(string fileName)
        {
            var httpRequest = _contextAccessor.HttpContext!.Request;
            var builder = new UriBuilder()
            {
                Scheme = httpRequest.Scheme,
                Host = httpRequest.Host.Host,
                Port = httpRequest.Host.Port ?? default,
                Path = Path.Combine(FileConfigurations.StaticPath, fileName),
            };

            var url = builder.ToString();
            return url;
        }

        #endregion
    }
}
