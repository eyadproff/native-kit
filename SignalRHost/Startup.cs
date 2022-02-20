using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SignalRHost.Controllers;
using SignalRHost.Hubs;
using SignalRHost.Services;

namespace SignalRHost
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
            services.AddCors();
            services.AddScoped<IServices, Services.Services>();
            services.AddSignalR();
            services.AddSingleton<CameraOperationHub>();
            services.AddSingleton<CrossmatchOperationHub>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NativeKitController", Version = "v1" });
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePathBase("/nk");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NativeKitController v1"));
            }

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<CameraOperationHub>("/cameraOperationHub");
                endpoints.MapHub<CrossmatchOperationHub>("/crossmatchOperationHub");
            });
        }
    }
}
