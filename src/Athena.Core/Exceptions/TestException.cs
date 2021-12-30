using System;

namespace Athena.Core.Exceptions
{
    public class TestException : Exception
    {
        public TestException()
        {

        }

        public TestException(string message) : base(message)
        {

        }

        public string Context { get; set; } = "A test exception message.";
    }
}
