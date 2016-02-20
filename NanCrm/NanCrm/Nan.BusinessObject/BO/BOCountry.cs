using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Data.Json;
using Biggy.Core;
using System.Collections;
using Newtonsoft.Json.Linq;
using Nan.BusinessObjects;

namespace Nan.BusinessObjects.BO
{
    public class CountryMD
    {
        public int ID { get; set; }
        [BOFieldAttribute(CFL=true,Desc="国家")]
        public string Name { get; set; }
        [BOFieldAttribute(CFL = true, Desc = "外文名")]
        public string ForeName { get; set; }
        [BOFieldAttribute(CFL = true, Desc = "缩写")]
        public string Alias { get; set; }
        [BOFieldAttribute(CFL = true, Desc = "首都")]
        public string Capital { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            CountryMD cty = (CountryMD)obj;
            return (cty.ID == this.ID
                    && cty.Name == this.Name
                    && cty.ForeName == this.ForeName
                    && cty.Alias == this.Alias
                    && cty.Capital == this.Capital);
        }
    }
    public class BOCountry : BusinessObject
    {

        private CountryMD m_boCty;
        public BOCountry()
        {
            base.m_boId = BOIDEnum.Country;
            m_boCty = new CountryMD();
        }
        public override bool Init()
        {
            m_boCty.ID = GetNextID();

            return base.Init();
        }

        public override bool OnIsValid()
        {
            bool isValid = true;
            //ArrayList list = ArrayList.Adapter(m_newDataList);
            List<CountryMD> list = new List<CountryMD>((IEnumerable<CountryMD>)m_newDataList);
            int i = 0;
            for (; i < list.Count;i++ )
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
        public override object GetBOTable()
        {
            return m_boCty;
        }
        //public override int GetMaxId()
        //{
        //    int maxId = 1;
        //    foreach (var item in m_newDataList)
        //    {
        //        CountryMD cty = (CountryMD)item;
        //        if (cty.ID > maxId)
        //        {
        //            maxId = cty.ID;
        //        }
        //    }
        //    return maxId;
        //}
    }
}
