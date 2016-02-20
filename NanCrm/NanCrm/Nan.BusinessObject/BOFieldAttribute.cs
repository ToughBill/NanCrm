using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BOFieldAttribute : Attribute
    {
        public bool CFL { get; set; }
        public string Desc { get; set; }
    }
}
