using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BackendApi.DataAccessLayer;
using Microsoft.Extensions.FileProviders;
using System.IO;
using BackendApi.Services.Abstract;
using BackendApi.Services.Concrete;
using BackendApi.DataAccessLayer.Abstract;
using BackendApi.DataAccessLayer.Concrete;
using BackendApi.DataAccessLayer.UnitOfWork;
using AutoMapper;

namespace BackendApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PostgresContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("NpgSql")));
            services.AddControllers();

            services.AddScoped<ICategoryRepos, CategoryRepos>();
            services.AddScoped<ICategoryService, CategoryService>();
            
            services.AddScoped<IStageRepos, StageRepos>();
            services.AddScoped<IStageService, StageService>();
            
            services.AddScoped<IFlatInfoRepos, FlatInfoRepos>();
            services.AddScoped<IFlatInfoService, FlatInfoService>();
            
            services.AddScoped<IImageRepos, ImageRepos>();
            services.AddScoped<IImageService, ImageService>();
            
            services.AddScoped<IWorksiteRepos , WorksiteRepos>();
            services.AddScoped<IWorksiteService, WorksiteService>();
            
            services.AddScoped<ICampaignRepos, CampaignRepos>();
            services.AddScoped<ICampaignService, CampaignService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMapper, Mapper>();



  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
