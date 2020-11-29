using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.Core.Model.AppSettings
{
    public class JWTOption
    {
        public string SecretKey { get; set; }
        public double ExpirationMinutes { get; set; }
    }
}
