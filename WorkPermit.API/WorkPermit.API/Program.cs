
using Microsoft.EntityFrameworkCore;
using WorkPermit.BLL.Services.WorkPermitServices;
using WorkPermit.DAL.Context;
using WorkPermit.DAL.Repo.WorkPermitRepo;

namespace WorkPermit.API
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



            #region Database
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            #endregion 


            #region Repo
            builder.Services.AddScoped<IWorkPermitRepo, WorkPermitRepo>();
            #endregion


            #region Service
            builder.Services.AddScoped<IWorkPermitServices, WorkPermitServices>();
            #endregion

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}