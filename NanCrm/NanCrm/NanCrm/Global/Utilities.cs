using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Newtonsoft.Json.Linq;
using Nan.BusinessObjects.BO;

namespace NanCrm.Global
{
    public class Utilities
    {
        public static List<T> ConvertList<T>(IList source) where T:new()
        {
            List<T> list = new List<T>();
            foreach (var item in source)
            {
                JObject jObj = (JObject)item;
                list.Add(jObj.ConvertToTarget<T>());
            }
            return list;
        }

    }
}
