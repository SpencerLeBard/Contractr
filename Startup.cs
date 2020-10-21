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
using ContractorFile.Repositories;
using ContractorFile.Services;
using System.Data;
using MySqlConnector;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ContractorFile
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddAuthentication(options =>
                 {
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 }).AddJwtBearer(options =>
                   {
                     options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
                     options.Audience = Configuration["Auth0:Audience"];
                   });
      services.AddCors(options =>
      {
        options.AddPolicy("CorsDevPolicy", builder =>
              {
                builder
                          .WithOrigins(new string[]{
                            "http://localhost:8080",
                            "http://localhost:8081"
                          })
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
              });
      });

      services.AddControllers();

      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      //NOTE SERVICE & REPOSITORY 

      services.AddTransient<ContractorService>();
      services.AddTransient<ContractorRepository>();
      services.AddTransient<JobService>();
      services.AddTransient<JobRepository>();
      services.AddTransient<ReviewService>();
      services.AddTransient<ReviewRepository>();

    }

    private IDbConnection CreateDbConnection()
    {
      var connectionString = Configuration.GetSection("DB").GetValue<string>("gearhost");
      return new MySqlConnection(connectionString);
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseCors("CorsDevPolicy");
      }

      Auth0ProviderExtension.ConfigureKeyMap(new List<string>() { "id" });

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

