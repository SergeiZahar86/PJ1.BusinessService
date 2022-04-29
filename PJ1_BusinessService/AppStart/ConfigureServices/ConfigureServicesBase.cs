using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PJ1_BusinessService.models;

namespace PJ1_BusinessService.AppStart.ConfigureServices
{
    /// <summary>
    /// Класс устанавливающий регистрацию и конфигурацию базовых сервисов
    /// </summary>
    public static class ConfigureServicesBase
    {
        /// <summary>
        /// Регистрация и конфигурации базовых сервисов
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="configuration">Конфигурация</param>
        public static void ConfigureServices(IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
                {
                    //config.UseSqlServer(Configuration.GetConnectionString(nameof(ApplicationDbContext)));
                    config.UseNpgsql(
                        configuration.GetConnectionString(nameof(ApplicationDbContext)));
                })
                .AddIdentity<AppUser, AppRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 4;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}