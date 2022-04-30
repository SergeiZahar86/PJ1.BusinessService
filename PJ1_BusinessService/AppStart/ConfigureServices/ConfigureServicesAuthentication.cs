using IdentityServer4.AccessTokenValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace PJ1_BusinessService.AppStart.ConfigureServices
{
    /// <summary>
    /// Регистрация и конфигурации сервисов аутентификации
    /// </summary>
    public static class ConfigureServicesAuthentication
    {
        /// <summary>
        /// Настроить аутентификацию и авторизацию.
        /// Ссылка на документацию:
        /// "https://identityserver4.readthedocs.io/en/latest/quickstarts/2_interactive_aspnetcore.html"
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureServices(IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    // Используется как резервная схема по умолчанию для всех
                    // остальных значений по умолчанию.
                    options.DefaultScheme =
                        IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    
                    // Используется ChallengeAsync(HttpContext, String, AuthenticationProperties)
                    // в качестве схемы по умолчанию .
                    options.DefaultChallengeScheme =
                        IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    
                    // Используется AuthenticateAsync(HttpContext, String) в
                    // качестве схемы по умолчанию .
                    options.DefaultAuthenticateScheme =
                        IdentityServerAuthenticationDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("Bearer",
                    options =>
                    {
                        // Получает или задает "Орган власти" для использования
                        // при вызове OpenIdConnect.
                        options.Authority = "https://localhost:10001";

                        // Получает или задает единственное допустимое значение
                        // аудитории для любого полученного токена OpenIdConnect.
                        options.Audience = "SwaggerAPI";

                        // Если равно false, то SSL при отправке токена не используется
                        options.RequireHttpsMetadata = true;

                        // Получает или задает параметры, используемые для проверки
                        // маркеров удостоверения.
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateAudience = false
                        };
                    });

            services.AddAuthorization();
        }
    }
}