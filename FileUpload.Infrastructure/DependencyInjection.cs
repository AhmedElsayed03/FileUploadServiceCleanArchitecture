using FileUpload.Application.Abstractions.Repositories;
using FileUpload.Application.Abstractions.Services.Storage;
using FileUpload.Application.Abstractions.Services;
using FileUpload.Application.Abstractions.UnitOfWork;
using FileUpload.Infrastructure.Data.Repositories;
using FileUpload.Infrastructure.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using FileUpload.Infrastructure.Servcies;
using FileUpload.Infrastructure.Servcies.Storage;

namespace FileUpload.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region Context
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<FileDbContext>(options =>
                options.UseSqlServer(connectionString));
            #endregion


            #region Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUploadedFileRepo, UploadedFileRepo>();
            #endregion


            #region Services
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IFileService, FileService>();
            #endregion


            return services;
        }
    }
}
