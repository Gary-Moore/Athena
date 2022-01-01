using Athena.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.App.Models;

namespace Web.App.Controllers
{
    public class SampleMessagesController : Controller
    {
        private readonly ILogger<SampleMessagesController> _logger;

        public SampleMessagesController(ILogger<SampleMessagesController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Messages(MessagesViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Error))
            {
                _logger.LogError(model.Error);
            }

            ViewBag.Confirmation = "Demo messages sent";

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Exception(MessagesViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Error))
            {
                try
                {
                    throw new TestException(model.Error);
                }
                catch (TestException ex)
                {
                    _logger.LogError(ex, model.Error);
                    throw;
                }
            }

            ViewBag.Confirmation = "Demo Exception Sent";

            return View("Index", model);
        }
    }
}
