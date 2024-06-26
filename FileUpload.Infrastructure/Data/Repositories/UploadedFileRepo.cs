using FileUpload.Application.Abstractions.Repositories;
using FileUpload.Domain.Entities;
using FileUpload.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Infrastructure.Data.Repositories
{
    public class UploadedFileRepo : GenericRepo<UploadedFile>, IUploadedFileRepo
    {
        private readonly FileDbContext _dbContext;

        public UploadedFileRepo(FileDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
