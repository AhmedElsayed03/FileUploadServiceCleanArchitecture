using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Application.Abstractions.Services.Storage
{
    public interface IStorageService
    {
        Task<string> UploadFileAsync(Stream file, string fileName);
    }
}
