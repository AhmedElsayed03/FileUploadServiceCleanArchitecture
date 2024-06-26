using FileUpload.Application.Abstractions.Repositories;
using FileUpload.Application.Abstractions.UnitOfWork;
using FileUpload.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
 
        private readonly FileDbContext _context;
        public IUploadedFileRepo UploadedFileRepo { get; }

        public UnitOfWork(FileDbContext context,
                          IUploadedFileRepo uploadedFileRepo)
        {
            _context = context;
            UploadedFileRepo = uploadedFileRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
