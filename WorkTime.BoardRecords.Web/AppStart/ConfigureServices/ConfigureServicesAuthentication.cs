using IdentityServer4.AccessTokenValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WorkTime.BoardRecords.Web.AppStart.ConfigureServices
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
                    options.DefaultScheme =
                        IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme =
                        IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme =
                        IdentityServerAuthenticationDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("Bearer",
                    options =>
                    {
                        options.Authority = "https://localhost:10001";
                        options.Audience = "SwaggerAPI";
                        options.RequireHttpsMetadata = false;

                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateAudience = false
                        };
                    });
            services.AddAuthorization();
        }
    }
}