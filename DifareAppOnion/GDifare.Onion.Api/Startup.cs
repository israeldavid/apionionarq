﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnionPattern.Api.Configuration.Startup.ApiVersioning;
using OnionPattern.Api.Configuration.Startup.AppSettings;
using OnionPattern.Api.Configuration.Startup.Logging;
using OnionPattern.Api.Configuration.Startup.Swagger;
using OnionPattern.DataAccess.EF;
using OnionPattern.DependencyInjection;
using OnionPattern.Domain.Constants;



namespace OnionPattern.Api
{
    /// <summary>
    /// Application Startup Configuration
    /// </summary>
    public class Startup
    {
        private readonly IHostingEnvironment environment;

        /// <summary>
        /// Configuration Root
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="environment">Hosting Environment</param>
        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            this.environment = environment;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddHttpClient();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ApiVersioningConfiguration.ConfigureService(services);

            services.AddMvc();
            services.AddHttpClient();

            LoadAppSettings.IntoInjector(services, Configuration);

            DependencyInjectorHost.Configure(services);

            // Swagger
            SwaggerStartupConfiguration.ConfigureService(services, environment);




        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="application"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="apiVersionDescriptionProvider"></param>
        public void Configure(IApplicationBuilder application,
                              ILoggerFactory loggerFactory,
                              IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (environment.IsEnvironment(EnvironmentTypes.Local))
            {
                application.UseDeveloperExceptionPage();

                application.UseStaticFiles();

                SwaggerStartupConfiguration.Configure(application, apiVersionDescriptionProvider);
            }

            CorrelationMiddleware.Configure(application);

            if (EnvironmentVariables.GetInMemoryDbValue())
            {
                var context = application.ApplicationServices.GetService<DataContext>();
                //MockDataInjector.Inject(context);
            }
            application.UseMvc();
        }
    }
}
