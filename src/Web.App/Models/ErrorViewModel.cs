using System;

namespace Web.App.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string TraceId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
