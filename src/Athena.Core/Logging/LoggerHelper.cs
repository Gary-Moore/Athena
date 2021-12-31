namespace Athena.Core.Logging
{
    public class LoggerHelper
    {
        public LoggerHelper()
        {

        }

        public void LogError(string product)
        {
            var detail = new LogDetail()
            {
                Product = product
            };


        }
    }
}
