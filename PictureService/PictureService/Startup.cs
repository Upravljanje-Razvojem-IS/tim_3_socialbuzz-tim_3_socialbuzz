using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
//using Microsoft.OpenApi.Models;
using PictureService.Data;
using PictureService.Interfaces;
using PictureService.Logger;
using PictureService.Mapper;
using PictureService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureService
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


            services.AddScoped<IPictureRepository, PictureRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostPictureRepository, PostPictureRepository>();
            services.AddScoped<IProfilePictureRepository, ProfilePictureRepository>(); 

            services.AddScoped<MockLogger>();
            services.AddControllers();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PictureConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PictureService", Version = "v1" });
            });



            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AllMapers());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);



            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.addjwtbearer(jwt =>
            //{
            //    jwt.tokenvalidationparameters = new tokenvalidationparameters
            //    {
            //        validateissuer = true,
            //        validateaudience = true,
            //        validatelifetime = true,
            //        validateissuersigningkey = true,
            //        validissuer = configuration["jwt:issuer"],
            //        validaudience = configuration["jwt:issuer"],
            //        issuersigningkey = new symmetricsecuritykey(encoding.utf8.getbytes(configuration["jwt:secret"]))
            //    };

            //});

            //services.AddDbContext<DatabaseContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("DatabaseString")));





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
         {
             if (env.IsDevelopment())
             {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PictureService v1"));
            }

             app.UseHttpsRedirection();

             app.UseRouting();
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();
                context.Database.Migrate();
            }
            app.UseAuthorization();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });
         }
     }








    }
