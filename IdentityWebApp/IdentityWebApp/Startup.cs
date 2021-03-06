using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IdentityWebApp.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.Logging;

namespace IdentityWebApp
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
          
            services.AddControllers();
            services.AddCors();
            services.AddDbContext<DataContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                      {
                          var userId = int.Parse(context.Principal.Identity.Name);
                          if (userId < 0)
                              context.Fail("UnAuthorized");
                          return Task.CompletedTask;
                      }
                };

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer=false,
                    ValidateAudience=true,
                    ValidateLifetime=false,
                   // ValidIssuer=Configuration["JwtToken:Issuer"],
                   // ValidAudience=Configuration["JwtToken:Issuer"],
                    IssuerSigningKey=new SymmetricSecurityKey(
                       // Encoding.UTF8.GetBytes(Configuration["JwtToken:SecretKey"]))
                        Encoding.ASCII.GetBytes(Configuration.GetSection("Secret").Value))
                };

          
        });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
