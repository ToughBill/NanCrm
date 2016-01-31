using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Data.Json;
using Biggy.Core;
using System.Collections;
using Nan.BusinessObjects.Database;
using Newtonsoft.Json.Linq;

namespace Nan.BusinessObjects.BO
{
    public class BusinessObject
    {
        protected BOIDEnum m_boId;
        protected string m_tbName;
        protected NanDataBase m_dbConn;
        protected List<BOIDEnum> m_relatedBO;
        protected IList m_dataList;
        protected IList m_newDataList;

        public virtual List<ValidValue> GetValieValue(string keyField, string descField)
        {
            return new List<ValidValue>();
        }

        public BusinessObject()
        {
            m_dbConn = NanDataBase.GetInstance();
            m_relatedBO = new List<BOIDEnum>() { BOIDEnum.BOSequence};
        }

        public virtual bool Init()
        {
            return true;
        }

        public virtual int GetNextID()
        {
            JsonStore<BOSequence> tbID = (JsonStore<BOSequence>)m_dbConn.CreateStoreFor<BOSequence>();
            var boIdList = new BiggyList<BOSequence>(tbID);
            var boid = boIdList.Find(x => x.BOID == (int)m_boId);
            if (boid != null)
            {
                return boid.NextID;
            }
            else
            {
                return 1;
            }
        }

        public static int GetBONextID(BOIDEnum boId)
        {
            JsonStore<BOSequence> tbID = (JsonStore<BOSequence>)NanDataBase.GetInstance().CreateStoreFor<BOSequence>();
            var boIdList = new BiggyList<BOSequence>(tbID);
            var boid = boIdList.Find(x => x.BOID == (int)boId);
            if (boid != null)
            {
                return boid.NextID;
            }
            else
            {
                return 1;
            }
        }

        public virtual int GetMaxId()
        {
            return 1;
        }
        public virtual object GetBOTable()
        {
            return null;
        }
        public virtual bool Add()
        {
            if (!OnIsValid())
                return false;
            bool ret = m_dbConn.SaveTableData(m_tbName, m_dataList);
            return ret;
        }
        public bool Update()
        {
            if (!OnIsValid())
                return false;
            if (!OnUpdate())
                return false;

            bool ret = UpdateNextID();
            if (ret)
            {
                ret = m_dbConn.SaveTableData(m_tbName, m_newDataList);
                if (ret)
                {
                    m_dataList = m_newDataList;
                }
            }

            return ret; 
        }
        public virtual bool OnUpdate()
        {
            return true;
        }
        public virtual bool OnIsValid()
        {
            return true;
        }
        public virtual bool UpdateNextID()
        {
            int maxId = GetMaxId();

            JsonStore<BOSequence> tbID = (JsonStore<BOSequence>)m_dbConn.CreateStoreFor<BOSequence>();
            var boIdList = new BiggyList<BOSequence>(tbID);
            BOSequence objId = boIdList.Find(x => { return x.BOID == (int)m_boId; });
            if (objId == null)
            {
                boIdList.Add(new BOSequence() { BOID = (int)m_boId, NextID = maxId + 1 });
            }
            else
            {
                objId.NextID = maxId+1;
                boIdList.Update(objId);
            }
            return true;
        }
        public virtual string GetTableName()
        {
            if (m_tbName == null)
            {
                m_tbName = GetEnumDescription(m_boId);
            }
            return m_tbName;
        }
        public string GetEnumDescription(Enum enumValue)
        {
            string str = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            System.ComponentModel.DescriptionAttribute da = (System.ComponentModel.DescriptionAttribute)objs[0];
            return da.Description;
        }
        public IList GetDataList()
        {
            if (m_dataList == null)
            {
                m_dataList = m_dbConn.GetTableData(GetTableName());
            }
            return m_dataList;
        }
        public virtual void SetDataList(IList list)
        {
            m_newDataList = list;
        }
        public virtual List<T> GetDataList<T>() where T : new()
        {
            JsonStore<T> tbObj = new JsonStore<T>(m_dbConn);
            var objList = new BiggyList<T>(tbObj);

            return objList.GetList();
        }
    }

    public class ValidValue
    {
        public string Value { get; set; }
        public string Description { get; set; }

        public ValidValue(string value, string desc)
        {
            Value = value;
            Description = desc;
        }
    }

    public static class BOConvertor
    {
        public static T ConvertToTarget<T>(this JObject source) where T : new()
        {
            T result = new T();
            var sourceProperties = source.Properties();
            var targetProperties = typeof(T).GetProperties();
            foreach (var pro in sourceProperties)
            {
                var tPro = Array.Find(targetProperties, x => x.Name == pro.Name);
                if (tPro!=null)
                {
                    switch (pro.Value.Type)
                    {
                        case JTokenType.Integer:
                            tPro.SetValue(result, int.Parse(pro.Value.ToString()), null);
                            break;
                        case JTokenType.String:
                            tPro.SetValue(result, pro.Value.ToString(), null);
                            break;
                        case JTokenType.Date:
                            tPro.SetValue(result, DateTime.Parse(pro.Value.ToString()), null);
                            break;
                        default: break;
                    }
                    //tPro.SetValue(targetProperties, pro.GetValue(source,null),null);
                    
                }
            }
            return result;
        }

    }
}
