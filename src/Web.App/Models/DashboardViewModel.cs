using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System.Collections.Generic;

namespace Web.App.Models
{
    public class DashboardViewModel
    {
        public List<ExceptionTelemetry> Exceptions { get; set; }
    }
}