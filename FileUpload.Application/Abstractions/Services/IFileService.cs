using FileUpload.Application.Models.DTOs;
using FileUpload.Application.Models.DTOs.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<FileResultDto> CreateLocalFileAsync(FileInputDto fileDto);
        Task<FileReadDto> GetFileAsync(int id);
    }
}
