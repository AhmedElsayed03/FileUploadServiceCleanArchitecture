using FileUpload.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Domain.Entities
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long Size { get; set; }
        public string Url { get; set; } = string.Empty;
        public FileType FileType { get; set; }

    }
}
