using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//using Autofac;
//using Autofac.Core;
//using Autofac.Extensions.DependencyInjection;
//using Business.Abstract;
//using Business.Concrete;
//using Business.DependencyResolvers.Autofac;
//using Core.Utilities.IoC;
//using Core.Utilities.Security.Encryption;
//using Core.Utilities.Security.JWT;
//using DataAccess.Abstract;
//using DataAccess.Concrete.EntityFramework;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Configuration;


//namespace WebApi
//{
//    public class Program
//    {
//        public static void Main(string[] args, TokenOptions tokenOptions)
//        {
//            var builder = WebApplication.CreateBuilder(args);


//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            //builder.Services.AddSingleton<IProductService, ProductManager>();      //constructor Iproductservice isterse ona bir productmanager newleyip ver
//            //builder.Services.AddSingleton<IProductDal, EfProductDal>();

//            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());  // there is a built-in ioc container but ı wanna use autofac instead

//            builder.Host.ConfigureContainer<ContainerBuilder>(options =>
//            {
//                options.RegisterModule(new AutofacBusinessModule());
//            });

//            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(options =>
//                {
//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateIssuer = true,
//                        ValidateAudience = true,
//                        ValidateLifetime = true,
//                        ValidIssuer = tokenOptions.Issuer,
//                        ValidAudience = tokenOptions.Audience,
//                        ValidateIssuerSigningKey = true,
//                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
//                    };
//                });
//            builder.Services.AddDependencyResolvers(new ICoreModule[] {
//                new CoreModule()
//            }) ;

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();

//        }
//    }
//}

