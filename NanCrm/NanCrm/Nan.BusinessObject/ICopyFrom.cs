using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects
{
    public interface ICopyFrom
    {
        object CopyFrom(object fromObj);
    }
}
