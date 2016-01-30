﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Data.Json;
using Biggy.Core;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace Nan.BusinessObjects.BO
{
    public class NanCountry
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ForeName { get; set; }
        public string Alias { get; set; }
        public string Capital { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            NanCountry cty = (NanCountry)obj;
            return (cty.ID == this.ID
                    && cty.Name == this.Name
                    && cty.ForeName == this.ForeName
                    && cty.Alias == this.Alias
                    && cty.Capital == this.Capital);
        }
    }
    public class BOCountry : BusinessObject
    {

        private NanCountry m_boCty;
        //JsonStore<BOCountry> m_tbCty;
        //protected JsonStore<BOCountry> TableCountry
        //{
        //    get 
        //    {
        //        if (m_tbCty == null)
        //        {
        //            m_tbCty = new JsonStore<BOCountry>(m_dbConn);
        //        }
        //        return m_tbCty; 
        //    }
        //}
        //BiggyList<BOCountry> m_tbCtyList;
        //protected BiggyList<BOCountry> CountryList
        //{
        //    get 
        //    {
        //        if (m_tbCtyList == null)
        //        {
        //            m_tbCtyList = new BiggyList<BOCountry>(m_tbCty);
        //        }
        //        return m_tbCtyList;
        //    }
        //}

        public BOCountry()
        {
            base.m_boId = BOIDEnum.Country;
            m_boCty = new NanCountry();
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
            List<NanCountry> list = new List<NanCountry>((IEnumerable<NanCountry>)m_newDataList);
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

        public override int GetMaxId()
        {
            int maxId = 1;
            foreach (var item in m_newDataList)
            {
                NanCountry cty = (NanCountry)item;
                if (cty.ID > maxId)
                {
                    maxId = cty.ID;
                }
            }
            return maxId;
        }
    }
}
