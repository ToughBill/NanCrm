﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class BOBPSearchResult : BusinessObject
    {
        public int      ID { get; set; }
        public int      CSPId { get; set; }
        public string   BP { get; set; }
        public string   Link { get; set; }
        public int?     Plantf { get; set; }
        public string   KeyWord { get; set; }
        public int?     KWLst { get; set; }
    }
}
