using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Azure.Monitor.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Monitor.Query.Models;
using Azure;

namespace Athena.Infrastructure.ApplicationInsights
{
    public class AppInsightsFetcher : IAppInsightsFetcher
    {
        public AppInsightsFetcher()
        {
        }

        public async Task<List<ExceptionTelemetry>> GetExceptions(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var credential = new ClientSecretCredential(
                "4cd01858-454d-4445-b56a-09b9b3af4793",
                "a7710dd5-51b1-4b5e-bbef-a3723bf34bdb",
                "dr18Q~k3U1inVBiR.c2eJff39rAPQRVQB6uP.aKm");
            var client = new LogsQueryClient(credential);

            string workspaceId = "cc0f3984-457c-48f6-aed0-f3b4663f74a7";

            Response<LogsQueryResult> result = await client.QueryWorkspaceAsync(
                workspaceId,
                $"AppExceptions | where TimeGenerated >= datetime('{startDate:O}') and TimeGenerated <= datetime('{endDate:O}')",
                new QueryTimeRange(TimeSpan.FromDays(1)));


            // Process the query results
            List<ExceptionTelemetry> exceptions = result.Value.Table.Rows.Select(row => new ExceptionTelemetry()
            {
                Timestamp = DateTimeOffset.Parse(row[1].ToString()),
                Exception = new Exception(row[9].ToString())
            }).ToList();


            return exceptions;
        }
    }
}
