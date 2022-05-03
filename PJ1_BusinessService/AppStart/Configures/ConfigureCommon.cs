using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PJ1_BusinessService.AppStart.Configures
{
    /// <summary>
    /// Класс с общими настройками
    /// </summary>
    public static class ConfigureCommon
    {
        /// <summary>
        /// Задает общие настройки
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Зарегистрируйте промежуточное программное обеспечение Swagger с
            //дополнительным действием настроек для параметров Di-Injected
            //app.UseSwagger();
            
            //Зарегистрируйте промежуточное программное обеспечение SwaggerUi с
            //дополнительным действием настроек для параметров Di-Injected
            // app.UseSwaggerUI(options =>
            // {
            //     options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI Demo");
            //     options.DocumentTitle = "Title";
            //     options.RoutePrefix = "docs";
            //     options.DocExpansion(DocExpansion.List);
            //     options.OAuthClientId("client_business");
            //     options.OAuthScopeSeparator(" ");
            //     options.OAuthClientSecret("client_secret_swagger");
            // });
        }
    }
}
