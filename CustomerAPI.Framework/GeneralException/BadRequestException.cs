using System;

namespace CustomerAPI.Framework.GeneralException
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
