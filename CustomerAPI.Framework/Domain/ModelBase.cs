using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.Framework.Domain
{
    public abstract class ModelBase : BaseResult
    {
        public abstract void Validate();
    }
}
