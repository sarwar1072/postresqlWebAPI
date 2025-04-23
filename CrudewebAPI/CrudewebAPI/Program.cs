using Autofac;
using Autofac.Extensions.DependencyInjection;
using Framework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Reflection;
using System.Text;

namespace CrudewebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

             var builder = WebApplication.CreateBuilder(args);
            
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            var assemblyName = Assembly.GetExecutingAssembly().FullName;
            var webHostEnvironment = builder.Environment.WebRootPath;

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule(new WebModule());
                containerBuilder.RegisterModule(new FrameworkModule(connectionString,
                        assemblyName, webHostEnvironment));
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                      options.UseNpgsql(connectionString, m => m.MigrationsAssembly(assemblyName)));


            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));
            ////builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            builder.Services.AddControllers();

            //builder.Services
            //    .AddIdentity<ApplicationUser, Role>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddUserManager<UserManager>()
            //    .AddRoleManager<RoleManager>()
            //    .AddSignInManager<SignInManager>()
            //.AddDefaultUI()
                //.AddDefaultTokenProviders();

            //Add Authentication
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(options =>
            //    {
            //        options.SaveToken = true;
            //        options.RequireHttpsMetadata = false;
            //        options.TokenValidationParameters = new TokenValidationParameters()
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:Secret"])),
            //            ValidateIssuer = true,
            //            ValidIssuer = builder.Configuration["JWT:Issuer"],
            //            ValidateAudience = true,
            //            ValidAudience = builder.Configuration["JWT:Audience"]
            //        };

            //    });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSites", policy =>
                {
                    policy.WithOrigins("https://localhost:44335") // Blazor client URL
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseCors("AllowSites"); // <- ADD THIS

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
