using Microsoft.Extensions.DependencyInjection;

namespace PJ1_BusinessService.AppStart.ConfigureServices
{
    /// <summary>
    /// Класс устанавливающий конфигурацию контроллеров
    /// </summary>
    public static class ConfigureServicesControllers
    {
        /// <summary>
        /// Конфигурация контроллеров
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            services.AddMvc();

        }
    }
}
