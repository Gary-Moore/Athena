using Microsoft.ApplicationInsights.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Athena.Infrastructure.ApplicationInsights
{
    public interface IAppInsightsFetcher
    {
        Task<List<ExceptionTelemetry>> GetExceptions(DateTimeOffset startDate, DateTimeOffset endDate);
    }
}