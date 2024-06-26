
using Microsoft.Extensions.FileProviders;
using FileUpload.Infrastructure;

namespace FileUpload.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region Services
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region Files Handling
            var staticFilesPath = Path.Combine(Environment.CurrentDirectory, "UploadedFiles");
            if (!Directory.Exists(staticFilesPath))
            {
                Directory.CreateDirectory(staticFilesPath);
            }
            //Configuration to let app use static files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticFilesPath),
                RequestPath = "/UploadedFiles" //Localhost:####/(Request Path)/Capture.PNG(Static File Name)
            });
            #endregion



            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
