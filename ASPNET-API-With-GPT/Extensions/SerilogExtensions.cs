using Serilog;

namespace ASPNET_API_With_GPT.Extensions
{
    public static class SerilogExtensions
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder,
                                                       IConfiguration configuration,
                                                       string appName)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            builder.Logging.ClearProviders();
            builder.Host.UseSerilog(Log.Logger, true);

            return builder;
        }
    }
}