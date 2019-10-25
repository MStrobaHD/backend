using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Helpers;
using ESA_api.Models;
using ESA_api.Repositories.Auth;
using ESA_api.Repositories.Common.CategoryRepository;
using ESA_api.Repositories.Common.CloudUploadRepository;
using ESA_api.Repositories.Education.CourseRepository;
using ESA_api.Repositories.Education.ExamRepository;
using ESA_api.Repositories.Education.LessonRepository;
using ESA_api.Repositories.Education.QuestionRepository;
using ESA_api.Repositories.Judge.AlgorithmCategoryRepository;
using ESA_api.Repositories.Judge.AlgorithmTaskRepository;
using ESA_api.Repositories.Judge.ComplexityRepository;
using ESA_api.Repositories.Judge.LevelRepository;
using ESA_api.Repositories.Judge.VerificationDataRepository;
using ESA_api.Services.Auth;
using ESA_api.Services.Common.CategoryService;
using ESA_api.Services.Common.CloudUploadService;
using ESA_api.Services.Education.CourseService;
using ESA_api.Services.Education.ExamService;
using ESA_api.Services.Education.LessonService;
using ESA_api.Services.Education.QuestionService;
using ESA_api.Services.Judge.AlgorithmCategoryService;
using ESA_api.Services.Judge.AlgorithmTaskService;
using ESA_api.Services.Judge.ComplexityService;
using ESA_api.Services.Judge.LevelService;
using ESA_api.Services.Judge.VerificationDataService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ESA_api
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
            services.AddDbContext<AppDatabaseContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.AddDirectoryBrowser();
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Education Support Application",
                    Description = "Application for support learning of C#",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mateusz Stroba",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Jakiekolwiek użycie zabronione",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamService, ExamService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAlgorithmTaskRepository, AlgorithmTaskRepository>();
            services.AddScoped<IAlgorithmTaskService, AlgorithmTaskService>();

            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ILessonService, LessonService>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<ICloudUploadRepository, CloudRepository>();
            services.AddScoped<ICloudUploadService, CloudUploadService>();

            // Judge Controllers
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<ILevelService, LevelService>();

            services.AddScoped<IAlgorithmCategoryRepository, AlgorithmCategoryRepository>();
            services.AddScoped<IAlgorithmCategoryService, AlgorithmCategoryService>();

            services.AddScoped<IComplexityRepository, ComplexityRepository>();
            services.AddScoped<IComplexityService, ComplexityService>();

            services.AddScoped<IVerificationDataRepository, VerificationRepository>();
            services.AddScoped<IVerificationDataService, VerificationDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseHttpsRedirection();

            //app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
            //    RequestPath = new PathString("/Resources")
            //});
            //app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
            //    RequestPath = new PathString("/StaticFiles")
            //});
            app.UseMvc();
        }
    }
}
