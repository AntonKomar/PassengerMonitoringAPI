using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PassengersMonitoring.Module.Passengers;
using PassengersMonitoring.ModuleSharedKernel;
using PassengersMonitoringApi.Binders;
using PassengersMonitoringApi.Filters;
using System;
using System.Collections.Generic;
using System.IO;

namespace PassengersMonitoringApi
{
    public class Startup
    {
        private readonly List<IModuleStartup> _modules;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _modules = new List<IModuleStartup>
            {
                new PassengersModuleStartup(),
                new IdentitiesModuleStartup(),
            };
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddDbContext<PassengersMonitoringContext>(options =>
                {
                    options.UseNpgsql(GetConnectionString(), b => {
                        b.UseNetTopologySuite();
                        b.MigrationsAssembly("PassengersMonitoring.Data"); 
                    });
                });

            // Identity 
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PassengersMonitoringContext>();

            // AutoMapper Configuration
            services.AddAutoMapper(
                (provider, config) =>
                {
                    config.AddExpressionMapping();
                    config.AddCollectionMappers();
                    config.AllowNullCollections = true;
                    config.ConstructServicesUsing(provider.GetRequiredService);
                }, AppDomain.CurrentDomain.GetAssemblies());

            // Enable Cors
            services.AddCors();

            // Fluent Validation of the model.
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddHttpContextAccessor();

            _modules.ForEach(module => module.ConfigureServices(services));

            services.AddSwaggerGen(c =>
            { 
                // Provide a full description for your API, terms of service or
                // even contact and licensing information
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "PassengersMonitoring API",
                        Version = "v1",
                        Description = "Created by Komar Industries",
                        Contact = new OpenApiContact
                        {
                            Name = "PassengersMonitoring Development Team",
                            Email = "anton.komar2979@gmail.com",
                        },
                    });

                // Add Grouping to SwaggerUI.
                c.DocInclusionPredicate((_, api) => !string.IsNullOrWhiteSpace(api.GroupName));

                // This is a fix for the deprecated method.
                c.TagActionsBy((api) =>
                {
                    List<string> groupNames = new List<string>
                    {
                        api.GroupName,
                    };

                    return groupNames;
                });

                c.CustomSchemaIds(x => x.FullName);

                // Include Descriptions from XML Comments
                var filePath = Path.Combine(AppContext.BaseDirectory, "PassengersMonitoringApi.xml");
                c.IncludeXmlComments(filePath);
            });

            services
                .AddMvcCore(options =>
                {
                    options.Filters.Add(typeof(ModelStateValidationFilter));

                    var readerFactory = services.BuildServiceProvider().GetRequiredService<IHttpRequestStreamReaderFactory>();
                    options.ModelBinderProviders.Insert(0, new HtmlStringBinderProvider(options.InputFormatters, readerFactory));
                })
                .AddApiExplorer()
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssemblyContaining<Startup>();
                    _modules.ForEach(m => config.RegisterValidatorsFromAssemblyContaining(m.GetType()));
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Formatting = Formatting.Indented;
                    opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opts.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    opts.SerializerSettings.NullValueHandling = NullValueHandling.Include;

                    //foreach (var converter in GeoJsonSerializer.Create().Converters)
                    //{
                    //    opts.SerializerSettings.Converters.Add(converter);
                    //}
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
            }
            else
            {
                app.UseHsts();
            }

            // Add MVC to the request pipeline.
            // Must proceed app.Use.Mvc().
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            _modules.ForEach(module => module.Configure(app.ApplicationServices));

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PassengersMonitoring API V1");
            });
        }

        private string GetConnectionString()
        {
            return Configuration["ConnectionStrings:PassengersMonitoringConnection"];
        }
    }
}
