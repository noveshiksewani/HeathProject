using HeathProject.DbContexts;
using HeathProject.Repository.Register;
using HeathProject.Service.Register;
using HeathProject.Repository;
using HeathProject.Repository.Login;
using HeathProject.Service;
using HeathProject.Service.Login;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HeathProject.Service.Posts;
using HeathProject.Repository.Posts;
using HeathProject.Repository.Admin;
using HeathProject.Service.Admin;
using HeathProject.Repository.Comments;
using HeathProject.Service.Comments;
using HeathProject.Service.Money;
using HeathProject.Service.DonateFood;
using HeathProject.Repository.DonateFood;
using HeathProject.Service.DonatePlasma;
using HeathProject.Repository.DonatePlasma;
using HeathProject.Repository.QuarantinePlaces;
using HeathProject.Service.QuarantinePlaces;
using HeathProject.Repository.OxygenFolder;
using HeathProject.Service.OxygenFolder;

namespace HeathProject
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
            
            services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            //services.AddDbContext<healthContext>();
            //string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContextPool<healthContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddControllers();

            services.AddScoped<IRegisterUserRepo, RegisterUserRepo>();
            services.AddScoped<IRegisterUserService, RegisterUserService>();
			services.AddScoped<ILoginRepo,LoginRepo>();
			services.AddScoped<ILoginService,LoginService>();
            services.AddScoped<ICommentsRepo,CommentsRepo>();
            services.AddScoped<ICommentsService,CommentsService>();
            services.AddScoped<IPostService,PostService>();
            services.AddScoped<IPostRepo,PostRepo>();
            services.AddScoped<IAdminRepo,AdminRepo>();
            services.AddScoped<IAdminService,AdminService>();
            services.AddScoped<IMoneyRepo,MoneyRepo>();
            services.AddScoped<IMoneyService,MoneyService>();
            services.AddScoped<IFoodService,FoodService>();
            services.AddScoped<IFoodRepo,FoodRepo>();
            services.AddScoped<IPlasmaService, PlasmaService>();
            services.AddScoped<IPlasmaRepo,PlasmaRepo>();
            services.AddScoped<IQuarantinePlaceRepo,QuarantinePlaceRepo>();
            services.AddScoped<IQuarantinePlaceService,QuarantinePlaceService>();
            services.AddScoped<IOxygen, OxygenRepo>();
            services.AddScoped<IOxygenService, OxygenService>();
            
           

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HeathProject", Version = "v1" });
            });
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<testContext>(options => options.UseMySql(mySqlConnectionStr, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql")));
            //services.AddDbContext<testContext>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = Configuration["Jwt:Issuer"],
           ValidAudience = Configuration["Jwt:Issuer"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
       };
   });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HeathProject v1"));
            }
            app.UseCors("AllowAll");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
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
