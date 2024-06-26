using FileUpload.Application.Abstractions.Services.Storage;
using FileUpload.Application.Abstractions.Services;
using FileUpload.Application.Models.DTOs.Files;
using FileUpload.Application.Models.DTOs;
using FileUpload.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;

        public FileController(IFileService fileService, IStorageService storageService, IConfiguration configuration)
        {
            _fileService = fileService;
            _storageService = storageService;
            _configuration = configuration;
        }

        [HttpPost("upload-file")]
        public async Task<Ok<FileResultDto>> CreateFile(IFormFile file)
        {
            var fileInput = new FileInputDto(file.FileName.GetExtension(),
                file.FileName.GetFileNameWithoutExtension(),
                file.Length,
                file.OpenReadStream());


            var fileResult = await _fileService.CreateLocalFileAsync(fileInput);
            return TypedResults.Ok(fileResult);

        }

        [HttpGet("get-file")]
        public async Task<Ok<FileReadDto>> GetFile(int id)
        {
            var files = await _fileService.GetFileAsync(id);
            return TypedResults.Ok(files);
        }
    }
}

            //#region Extention Checking

            //var extension = Path.GetExtension(file.FileName);

            ////Change in appsettings.json
            //var extensionList = _configuration.GetSection("AllowedFileExtenstions").Get<string[]>();

            //bool isExtensionAllowed = extensionList!.Contains(extension,
            //    StringComparer.InvariantCultureIgnoreCase);
            //if (!isExtensionAllowed)
            //{
            //    return BadRequest("Format not allowed");
            //}
            //#endregion




            //#region Length Checking

            //bool isSizeAllowed = ImageFile.Length is > 0 and < 5_000_000; //Picture Size (Minimum: >0 and Max: 5MB)

            //if (!isSizeAllowed)
            //{
            //    return BadRequest("Size is Larger than allowed size");
            //}
            //#endregion