using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class KWListMD
    {
        public int          ID { get; set; }
        public string       Name { get; set; }
        public string       Desc { get; set; }
        public List<int>    KeyWrodIds {get;set;}
    }
    public class KWListDetailMD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string KeyWords { get; set; }

        private KWListMD m_kwMd;
        public KWListDetailMD(KWListMD kwMd)
        {
            this.ID = kwMd.ID;
            this.Name = kwMd.Name;
            this.Desc = kwMd.Desc;
            m_kwMd = kwMd;
        }

        public KWListMD GetOrignalMD()
        {
            return m_kwMd;
        }
    }

    public class BOKWList : BusinessObject
    {
        public BOKWList()
        {
            base.m_boId = BOIDEnum.KeyWordList;
            m_boTable = new KWListMD();
        }
        public override bool Init()
        {
            KWListMD kwlMd = (KWListMD)m_boTable;
            kwlMd.ID = GetNextID();

            return base.Init();
        }

        public List<KWListDetailMD> GetDetialedMD()
        {
            List<KWListDetailMD> result = new List<KWListDetailMD>();
            return result;
        }
    }
}
