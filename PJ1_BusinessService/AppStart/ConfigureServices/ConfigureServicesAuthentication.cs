using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PJ1_BusinessService.AppStart.LibraryModels;

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
                // .AddIdentityServerAuthentication(options =>
                // {
                //     options.ApiName = "SwaggerAPI";
                //     options.Authority = "https://localhost:10001";
                //     options.RequireHttpsMetadata = false;
                // })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                    
                    // Класс JwtBearerOptions (конфигурирование которого происходит в этом блоке
                    // кода) предоставляет сведения, необходимые для управления поведением
                    // ПО промежуточного слоя проверки подлинности носителя
                    options =>
                    {
                        //options.SaveToken = true;
                        //options.IncludeErrorDetails = true;
                        // Получает или задает "Орган власти" для использования
                        // при вызове OpenIdConnect.
                        options.Authority = "https://localhost:10001";
                        //options.ClaimsIssuer = 

                        // Получает или задает единственное допустимое значение
                        // аудитории для любого полученного токена OpenIdConnect.
                        options.Audience = "SwaggerAPI";
                        //options.Audience = "https://localhost:10003";

                        // Если равно false, то SSL при отправке токена не используется
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParametersMy()
                        {
                            //TODO сделать валидацию по времени жизни и посмотреть
                            //todo другие свойства
                            ValidateAudience = false,
                            ValidTypes = new[] { "at+jwt" }
                        };
                    })
                ;

            services.AddAuthorization();
        }
    }
}