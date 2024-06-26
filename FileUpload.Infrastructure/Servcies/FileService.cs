using FileUpload.Application.Abstractions.Services.Storage;
using FileUpload.Application.Abstractions.Services;
using FileUpload.Application.Abstractions.UnitOfWork;
using FileUpload.Application.Models.DTOs.Files;
using FileUpload.Domain.Entities;
using FileUpload.Domain.Enum;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Application.Models.DTOs;

namespace FileUpload.Infrastructure.Servcies
{
    public class FileService : IFileService
    {
        private readonly FileConfigurations _fileConfiguration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;


        public FileService(IOptions<FileConfigurations> fileOptions,
            IUnitOfWork unitOfWork,
            IStorageService storageService)
        {
            _fileConfiguration = fileOptions.Value;
            _unitOfWork = unitOfWork;
            _storageService = storageService;

        }

        #region Create OCI Files
        public async Task<FileResultDto> CreateFileAsyncOCI(FileInputDto fileDto)
        {

            var fileType = GetFileType(fileDto.Extention);
            var savedFileName = Guid.NewGuid().ToString() + fileDto.Extention;
            var url = await _storageService.UploadFileAsyncOCI(fileDto.Stream!, savedFileName);

            var uploadedFile = new UploadedFile
            {
                Name = fileDto.Name,
                Size = fileDto.Length,
                FileType = fileType,
                Url = url

            };
            await _unitOfWork.UploadedFileRepo.AddAsync(uploadedFile);
            await _unitOfWork.SaveChangesAsync();

            return new FileResultDto(uploadedFile.Id, url);
        }
        #endregion

        #region Create Local Files
        public async Task<FileResultDto> CreateLocalFileAsync(FileInputDto fileDto)
        {

            var fileType = GetFileType(fileDto.Extention);
            var savedFileName = Guid.NewGuid().ToString() + fileDto.Extention;
            var url = await _storageService.UploadFileAsync(fileDto.Stream!, savedFileName);

            var uploadedFile = new UploadedFile
            {
                Name = fileDto.Name,
                Size = fileDto.Length,
                FileType = fileType,
                Url = url

            };
            await _unitOfWork.UploadedFileRepo.AddAsync(uploadedFile);
            await _unitOfWork.SaveChangesAsync();

            return new FileResultDto(uploadedFile.Id, url);
        }
        #endregion

        private FileType GetFileType(string extension)
        {
            return extension switch
            {
                _ when _fileConfiguration.WordExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase) => FileType.Word,
                _ when _fileConfiguration.PdfExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase) => FileType.Pdf,
                _ when _fileConfiguration.ImageExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase) => FileType.Image,
                _ when _fileConfiguration.VideoExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase) => FileType.Video,
                _ => default
            };
        }


        public async Task<FileReadDto> GetFileAsync(int id)
        {
            var File = await _unitOfWork.UploadedFileRepo.GetByIdAsync(id);
            return new FileReadDto { Id = File!.Id, Name = File.Name, Url = File.Url };
        }

    }
}
