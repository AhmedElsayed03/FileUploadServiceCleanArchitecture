using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Application.Models.DTOs.Files
{
    public class FileInputDto
    {
        public string Extention { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long Length { get; set; }
        public Stream? Stream { get; set; }
        public int MemberId { get; set; }

        public FileInputDto(string extention, string name, long length, Stream? stream)
        {
            Extention = extention;
            Name = name;
            Length = length;
            Stream = stream;
        }
    }
}
