using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Application.Models.DTOs
{
    public class UploadFileDto
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
    }
}
