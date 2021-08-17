using DeliveryService.API.Interfaces;
using DeliveryService.API.MockedLogger;
using DeliveryService.API.Services;
using DeliveryService.API.ValidationFilter;
using DeliveryService.API.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace DeliveryService.API
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
            
            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;
            });
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidationModelAttribute));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("DeliveryServiceOpenAPISpecification",
                    new OpenApiInfo { 
                        Title = "Delivery Service API", 
                        Version = "v1",
                        Description = "This API is used to calculate the delivery costs of ordered products!",
                        Contact = new OpenApiContact
                        {
                            Name = "Tamara Žuvela",
                            Email = "zuvelatamara@gmail.com"
                        }
                    });

                var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name }.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                c.IncludeXmlComments(xmlCommentsPath);
            });

            services.AddDbContext<DeliveryServiceDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DatabaseString"))
            );

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]))
                };
              
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Moze se koristiti AddSingleton, AddScoped i AddTransient
            //AddTransient - vezuje se za zivotni ciklus
            //AddSingleton - kada se napravi istanca ona jedna postoji i radimo sa njom 
            //AddScoped - pravim instancu svaki put kada dodje novi request

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IPriceDistance, PriceDistanceService>();
            services.AddScoped<IWeightRangeService, WeightRangeService>();
            services.AddScoped<ISaleService, SaleService>();

            services.AddSingleton<IFakeLogger, FakeLogger>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-development");

                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/DeliveryServiceOpenAPISpecification/swagger.json", "DeliveryService API v1"));
            }

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
