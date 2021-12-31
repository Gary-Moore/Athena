using System.Collections.Generic;

namespace Athena.Core.Logging
{
    public class LogDetail
    {
        public string Product { get; set; }
        public string ApplicationName { get; set; }
        public Dictionary<string, object> AdditionalInformation { get; set; } = new Dictionary<string, object>();
    }
}
