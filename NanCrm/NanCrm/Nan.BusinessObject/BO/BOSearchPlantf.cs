using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class SearchPlantfMD 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> WebSites { get; set; }
        public string   Desc { get; set; }

        public SearchPlantfMD()
        {
            this.Name = this.Desc = string.Empty;
            WebSites = new List<string>();
        }
    }

    public class BPSearchPlantf : BusinessObject
    {
        public BPSearchPlantf()
        {
            base.m_boId = BOIDEnum.SearchPlantf;
            m_boTable = new SearchPlantfMD();
        }

        public override bool Init()
        {
            base.Init();
            SearchPlantfMD boPro = (SearchPlantfMD)m_boTable;
            boPro.ID = GetNextID();

            return true;
        }
    }
}
