namespace HttpWebServer.Server.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        public BadRequestException()
            : this("Invalid request")
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }
    }
}
