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
    public class CountryMD: ICopyFrom
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

        public CountryMD()
        {
            this.Name = this.ForeName = this.Alias = this.Capital =string.Empty;
        }
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

        public object CopyFrom(object fromObj)
        {
            CountryMD from = (CountryMD)fromObj;
            this.ID = from.ID;
            this.Name = from.Name;
            this.ForeName = from.ForeName;
            this.Alias = from.Alias;
            this.Capital = from.Capital;
            return this;
        }
    }
    [BOAttribute(Name="城市")]
    public class BOCountry : BusinessObject
    {

        //private CountryMD m_boCty;
        public BOCountry()
        {
            base.m_boId = BOIDEnum.Country;
            m_boTable = new CountryMD();
        }
        public override bool Init()
        {
            CountryMD ctyTb = (CountryMD)m_boTable;
            ctyTb.ID = GetNextID();

            return base.Init();
        }

        public override bool OnIsValid()
        {
            bool isValid = true;
            
            //List<CountryMD> list = new List<CountryMD>((IEnumerable<CountryMD>)m_newDataList);
            //int i = 0;
            //for (; i < list.Count;i++ )
            //{
            //    if (string.IsNullOrEmpty(list[i].Name))
            //    {
            //        if (i < list.Count - 1)
            //        {
            //            isValid = false;
            //            break;
            //        }
            //        else
            //        {
            //            m_newDataList.RemoveAt(i);
            //        }
            //        break;
            //    }
            //}
            CountryMD ctyTb = (CountryMD)m_boTable;
            if (string.IsNullOrEmpty(ctyTb.Name))
            {
                isValid = false;
            }
            return isValid;
        }
        //public override object GetBOTable()
        //{
        //    return m_boCty;
        //}
        public override bool GetById(int id)
        {
            CountryMD mkt = m_dbConn.GetTableData(GetTableName(), id).ConvertToTarget<CountryMD>();
            m_boTable = mkt;

            return m_boTable == null;
        }
        public bool GetByName(string ctyName)
        {
            JObject mkt = GetDataList().Cast<JObject>().ToList().Find(x=>(x.ConvertToTarget<CountryMD>()).Name==ctyName);
            m_boTable = mkt.ConvertToTarget<CountryMD>(); ;

            return m_boTable == null;
        }
    }
}
