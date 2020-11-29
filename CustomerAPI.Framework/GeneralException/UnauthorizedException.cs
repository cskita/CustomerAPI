using System;

namespace CustomerAPI.Framework.GeneralException
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
