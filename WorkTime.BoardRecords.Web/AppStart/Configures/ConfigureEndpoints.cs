using Microsoft.AspNetCore.Builder;

namespace WorkTime.BoardRecords.Web.AppStart.Configures
{
    /// <summary>
    /// Класс для настройки источника информации
    /// </summary>
    public static class ConfigureEndpoints
    {
        /// <summary>
        /// Настроить маршрутизацию, Cors, и т.д.
        /// </summary>
        /// <param name="app"></param>
        public static void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors("DefaultPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
