using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class BPMD : ICopyFrom
    {
        public int      ID { get; set; }
        public string   Code { get; set; }
        public string   Name { get; set; }
        public int   Country { get; set; }
        public string   Site { get; set; }
        public string   Email { get; set; }
        public string   CtPeson { get; set; }
        public string   Phone { get; set; }
        public int      Level { get; set; }
        public string   Remark { get; set; }
        public int   Type { get; set; }

        public BPMD()
        {
            this.Code = this.Name = this.Site = 
                this.Email = this.CtPeson = this.Phone = this.Remark = string.Empty;
        }
        public object CopyFrom(object fromObj)
        {
            BPMD source = (BPMD)fromObj;
            if (source == null || source == this)
            {
                return this;
            }
            this.ID = source.ID;
            this.Code = source.Code;
            this.Name = source.Name;
            this.Country = source.Country;
            this.Site = source.Site;
            this.Email = source.Email;
            this.CtPeson = source.CtPeson;
            this.Phone = source.Phone;
            this.Level = source.Level;
            this.Remark = source.Remark;
            return this;
        }
    }

    public class BOBP : BusinessObject
    {
        public const int Potential = 0;
        public const int Customer = 1;
        public const int Vendor = 2;

        public BOBP()
        {
            base.m_boId = BOIDEnum.BP;
            m_boTable = new BPMD();
        }

        public override bool Init()
        {
            base.Init();
            BPMD boPro = (BPMD)m_boTable;
            boPro.ID = GetNextID();

            return true;
        }

        public List<ValidValue> GetBPTypeValidValue()
        {
            return new List<ValidValue>() { new ValidValue(BOBP.Potential.ToString(),"潜在客户"),
                                            new ValidValue(BOBP.Customer.ToString(),"客户"),
                                            new ValidValue(BOBP.Vendor.ToString(),"供应商") };
        }
    }
}
