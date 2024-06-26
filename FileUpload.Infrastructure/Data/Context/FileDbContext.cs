using FileUpload.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace FileUpload.Infrastructure.Data.Context
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        {
            
        }
        public DbSet<UploadedFile> Files => Set<UploadedFile>();
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);






            #region Mapping Strategy
            //Use Table-per-Type Strategy 
            //builder.Entity<IdentityUser>()
            //    .UseTptMappingStrategy();

            //Use Table-per-Hierarchy Strategy 
            //builder.Entity<IdentityUser>()
            //    .UseTphMappingStrategy();
            #endregion
        }
    }
}
