using FileUpload.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Application.Abstractions.Repositories
{
    public interface IUploadedFileRepo : IGenericRepo<UploadedFile>
    {

    }
}
