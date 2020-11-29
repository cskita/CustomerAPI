using System;

namespace CustomerAPI.Framework.GeneralException
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
