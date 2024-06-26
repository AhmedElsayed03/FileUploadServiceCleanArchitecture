using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Application.Models.DTOs.Files
{
    public class FileConfigurations
    {
        public const string SectionName = "FileConfigurations";
        public const string StaticPath = "UploadedFiles";
        public long Size { get; set; }
        public string Path { get; set; } = string.Empty;
        public string[] WordExtensions { get; set; } = [];
        public string[] PdfExtensions { get; set; } = [];
        public string[] ImageExtensions { get; set; } = [];
        public string[] VideoExtensions { get; set; } = [];
    }
}
