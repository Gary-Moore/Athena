using Athena.Infrastructure.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web.App.Models;

namespace Web.App.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IAppInsightsFetcher _telemetryClient;

        public DashboardController(IAppInsightsFetcher appInsightsFetcher)
        {
            _telemetryClient = appInsightsFetcher;
        }

        public async Task<IActionResult> Index()
        {
            // get exceptions from Application Insights
            var exceptions = await _telemetryClient.GetExceptions(
                               startDate: DateTimeOffset.Now.AddDays(-1),
                               endDate: DateTimeOffset.Now);



            // create new view model with exceptions
            var viewModel = new DashboardViewModel
            {
                Exceptions = exceptions
            };
            // return viewmodel to view

            return View(viewModel);
        }



    }
}
