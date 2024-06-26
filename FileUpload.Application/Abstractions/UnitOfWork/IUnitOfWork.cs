using FileUpload.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {

        public IUploadedFileRepo UploadedFileRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
