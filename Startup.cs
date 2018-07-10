using keylookup.Application.UseCases.LookupFromCache;
using keylookup.Common;
using keylookup.Infrastructure;
using keylookup.Infrastructure.Cache;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle;
namespace keylookup
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
            services.AddMvc();
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(conf =>
            {
                conf.SingleApiVersion(new Swashbuckle.Swagger.Model.Info()
                {
                    Title = "Key lookup HTTP API",
                    Version = "v1",
                    Description = "The Key lookup service API",
                    TermsOfService = "Terms Of Service"
                });      
            });
            services.AddSingleton<ICache, RedisCache>();
            services.AddSingleton<IGuidGenerator, GuidGenerator>();
            services.AddScoped<LookupFromCache>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {

                });
            });
            app.UseSwagger().UseSwaggerUi();
            app.UseMvc(rotues =>
            {
                rotues.MapRoute("default","{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
