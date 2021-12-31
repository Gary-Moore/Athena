using Serilog;

namespace Athena.Core.Logging
{
    public static class LoggingConfigurationExtensions
    {
        public static LoggerConfiguration ConfigureBaseLogging(
            this LoggerConfiguration loggerConfiguration, LogDetail logDetail)
        {
            loggerConfiguration.Enrich.WithProperty(nameof(logDetail.Product), logDetail.Product);
            loggerConfiguration.Enrich.WithProperty(nameof(logDetail.ApplicationName), logDetail.ApplicationName);

            return loggerConfiguration;
        }
    }
}
