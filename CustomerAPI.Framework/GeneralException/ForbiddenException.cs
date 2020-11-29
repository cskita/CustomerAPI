using System;

namespace CustomerAPI.Framework.GeneralException
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message)
        {
        }
    }
}
