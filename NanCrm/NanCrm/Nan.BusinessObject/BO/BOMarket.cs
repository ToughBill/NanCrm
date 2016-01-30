using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class Market
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
    public class BOMarket : BusinessObject
    {
        private Market m_boMkt;
        public BOMarket()
        {
            base.m_boId = BOIDEnum.Market;
            m_boMkt = new Market();
        }

        public override bool Init()
        {
            m_boMkt.ID = GetNextID();

            return base.Init();
        }

        public override bool OnIsValid()
        {
            bool isValid = true;
            List<Market> list = new List<Market>((IEnumerable<Market>)m_newDataList);
            int i = 0;
            for (; i < list.Count; i++)
            {
                if (string.IsNullOrEmpty(list[i].Name))
                {
                    if (i < list.Count - 1)
                    {
                        isValid = false;
                        break;
                    }
                    else
                    {
                        m_newDataList.RemoveAt(i);
                    }
                    break;
                }
            }
            return isValid;
        }
    }
}
