using Microsoft.AspNetCore.Diagnostics;
using SuficienciaWebII.DAOs;
using SuficienciaWebII.Exceptions;
using SuficienciaWebII.Services;

namespace SuficienciaWebII
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddExceptionHandler(options =>
            {
                options.ExceptionHandler = GlobalExceptionHandler.Handle;
                options.AllowStatusCode404Response = true;
            });

            services.AddSwaggerConfiguration();
            services.AddAuthenticationConfiguration();
            services.AddDatabaseConfiguration();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IComandasServices, ComandasServices>();
            services.AddTransient<IValidacoesService, ValidacoesService>();
            services.AddTransient<IComandasDAO, ComandasDAO>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}