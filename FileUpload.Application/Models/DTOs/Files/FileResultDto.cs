using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Application.Models.DTOs.Files
{
    public class FileResultDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        public FileResultDto(int id, string url)
        {

            Id = id;
            Url = url;
        }
    }
}
