using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace Web.App.Infrastructure
{
    public class AthenaTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            if (string.IsNullOrEmpty(telemetry.Context.Cloud.RoleName))
            {
                telemetry.Context.Cloud.RoleName = "Athena-WebApp";
                telemetry.Context.Cloud.RoleInstance = "Athena-Web-Application";
            }
        }
    }
}
