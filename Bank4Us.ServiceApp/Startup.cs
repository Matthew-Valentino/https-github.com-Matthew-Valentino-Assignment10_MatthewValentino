using Bank4Us.BusinessLayer.Core;
using Bank4Us.BusinessLayer.Managers.AccountManagement;
using Bank4Us.BusinessLayer.Managers.CustomerManagement;
using Bank4Us.BusinessLayer.Rules;
using Bank4Us.DataAccess.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NRules;
using NRules.Fluent;
using Microsoft.OpenApi.Models;


namespace Bank4Us.ServiceApp
{
    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 9 focusing on creating a service application           
    /// </summary>
    /// 
    public class Startup
    {
        //Startup file is based on textbook example with assistance from Github
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var ruleset = new RuleRepository();
            ruleset.Load(x => x.From(typeof(AccountClassificationRule).Assembly));

            var brefactory = ruleset.Compile();

            ISession businessRulesEngine = brefactory.CreateSession();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<DataContext>();
            services.AddScoped<IRepository, Repository>();
            services.AddSingleton<ISession>(businessRulesEngine);
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<BusinessManagerFactory>();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                ;
            services.AddCors(options =>
            {
                options.AddPolicy("CarsPolicy",
                  builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddSwaggerGen(c =>
            {
                //c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank4Us API", Version = "V1" });

            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("CorsPolicy");

            LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                       .AddFilter("System", LogLevel.Warning)
                       .AddFilter("Bank4Us.ServiceApp.Program", LogLevel.Debug)
                       .AddConsole();
            }
            );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank4Us API V1");

            });

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}