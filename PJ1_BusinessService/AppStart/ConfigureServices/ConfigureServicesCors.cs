using Microsoft.Extensions.DependencyInjection;

namespace PJ1_BusinessService.AppStart.ConfigureServices
{
    /// <summary>
    /// Класс устанавливающий CORS конфигурацию
    /// </summary>
    public class ConfigureServicesCors
    {
        /// <summary>
        /// Устанавливает CORS конфигурацию
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    //builder.AllowCredentials();
                    //builder.WithOrigins("http://localhost:4200");
                });
            });
        }
    }
}