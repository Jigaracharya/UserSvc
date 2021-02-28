using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace UserSvc.Infrastructure.Extensions
{
    public static class LoggingInstaller
    {
        public static void AddCustomLoggingService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(l =>
            {   
                l.AddSerilog();
            });

            services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(provider =>
            {
                var factory = provider.GetRequiredService<ILoggerFactory>();
                return factory.CreateLogger("GenericLogger");
            });

            var config = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console();            

            Log.Logger = config.CreateLogger();
        }

        public static void UseCustomHttpLoggingService(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSerilogRequestLogging();
        }
    }
}
