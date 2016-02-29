using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Data.Json;
using Biggy.Core;
using System.Collections;
using Nan.BusinessObjects.Database;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Nan.BusinessObjects.BO
{
    public class BusinessObject
    {
        protected BOIDEnum m_boId;
        protected string m_tbName;
        protected NanDataBase m_dbConn;

        protected List<BOIDEnum> m_relatedBO;
        protected object m_boTable;
        protected IList m_dataList;
        protected IList m_newDataList;
        protected IList m_removedDataList;
        public static Dictionary<BOIDEnum, IList> BODataPool = new Dictionary<BOIDEnum, IList>();

        public static DeleBoErrorHandler OnErrorHandler;
        public void ReportStatusMessage(SatusMessageInfo err)
        {
            if (BusinessObject.OnErrorHandler != null)
            {
                BusinessObject.OnErrorHandler(err);
            }
        }
        public virtual List<ValidValue> GetValieValue(string keyField, string descField)
        {
            List<ValidValue> result = new List<ValidValue>();

            IList source = GetDataList();
            foreach (var item in source)
            {
                JObject jObj = (JObject)item;
                ValidValue vv = new ValidValue(jObj.GetValue(keyField).ToString(), jObj.GetValue(descField).ToString());
                result.Add(vv);
            }

            return result;
        }

        public BusinessObject()
        {
            m_dbConn = NanDataBase.GetInstance();
            m_relatedBO = new List<BOIDEnum>();
        }

        public virtual bool Init()
        {
            return true;
        }

        public virtual int GetNextID()
        {
            int maxId = GetMaxId();
            return ++maxId;
        }

        public static int GetBONextID(BOIDEnum boId)
        {
            string tbPath = Path.Combine(NanDataBase.GetInstance().GetDBPath(), BusinessObject.GetEnumDescription(boId));
            if (!Directory.Exists(tbPath))
            {
                return 1;
            }

            int maxId = 0;
            string[] files = Directory.GetFiles(tbPath);
            if (files.Length > 0)
            {
                maxId = files.Max(x => int.Parse(Path.GetFileName(x)));
            }
            return ++maxId;
        }

        public virtual int GetMaxId()
        {
            int maxId = 0;
            string tbPath = Path.Combine(m_dbConn.GetDBPath(), GetTableName());
            if (!Directory.Exists(tbPath))
            {
                return maxId;
            }
            string[] files = Directory.GetFiles(tbPath);
            if(files.Length > 0)
            {
                maxId = files.Max(x => int.Parse(Path.GetFileName(x)));
            }

            return maxId;
        }
        public virtual object GetBOTable()
        {
            return m_boTable;
        }
        public virtual void SetBOTable(object table)
        {
            m_boTable = table;
        }
        public virtual bool Add()
        {
            if (!OnIsValid())
                return false;
            bool ret = m_dbConn.SaveTableData(m_tbName, m_boTable);
            return ret;
        }
        public bool Update()
        {
            if (!OnIsValid())
                return false;
            if (!OnUpdate())
                return false;

            bool ret = true;
            if (m_boTable != null)
            {
                ret = m_dbConn.SaveTableData(m_tbName, m_boTable);
                if (!ret)
                {
                    return false;
                }
            }
            if(ret)
            {
                ReportStatusMessage(new SatusMessageInfo(MessageType.Info,MessageCode.None,this,"更新成功！"));
            }
            else
            {
                ReportStatusMessage(new SatusMessageInfo(MessageType.Error, MessageCode.None, this, "更新失败！"));
            }
            return ret; 
        }

        public virtual bool UpdateBatch()
        {
            if (!OnIsValidBatch())
                return false;
            bool ret = true;
            if (m_newDataList != null && m_newDataList.Count > 0)
            {
                ret = m_dbConn.SaveTableData(m_tbName, m_newDataList);
                if (!ret)
                {
                    return false;
                }
                m_dataList = m_newDataList;
            }
            if (m_removedDataList != null && m_removedDataList.Count > 0)
            {
                ret = m_dbConn.RemoveTableData(m_tbName, m_removedDataList);
                if (!ret)
                {
                    return false;
                }
                m_removedDataList.Clear();
            }

            if (ret)
            {
                ReportStatusMessage(new SatusMessageInfo(MessageType.Info, MessageCode.None, this, "更新成功！"));
            }
            else
            {
                ReportStatusMessage(new SatusMessageInfo(MessageType.Error, MessageCode.None, this, "更新失败！"));
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
        public virtual bool OnIsValidBatch()
        {
            return true;
        }
        public virtual string GetTableName(BOIDEnum boid)
        {
            return GetEnumDescription(boid);
        }
        public virtual string GetTableName()
        {
            if (m_tbName == null)
            {
                m_tbName = GetEnumDescription(m_boId);
            }
            return m_tbName;
        }

        public static string GetEnumDescription(Enum enumValue)
        {
            string str = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            System.ComponentModel.DescriptionAttribute da = (System.ComponentModel.DescriptionAttribute)objs[0];
            return da.Description;
        }

        public static string GetBOName(BOIDEnum boid)
        {
            string name = string.Empty;
            BusinessObject bo = BOFactory.GetBO(boid);
            var attr = bo.GetType().GetCustomAttributes(typeof(BOAttribute), false).First();
            if (attr == null)
            {
                return name;
            }
            return ((BOAttribute)attr).Name;
        }

        public virtual bool GetById(int id)
        {
            m_boTable = m_dbConn.GetTableData(m_tbName, id);

            return m_boTable == null;
        }

        public IList GetDataList(bool forceReload = false)
        {
            if (m_dataList == null || forceReload)
            {
                m_dataList = m_dbConn.GetTableData(GetTableName());
                //if (!BusinessObject.BODataPool.ContainsKey(m_boId))
                //{
                //    BusinessObject.BODataPool[m_boId] = m_dataList;
                //}
                
                //foreach (BOIDEnum id in m_relatedBO)
                //{
                //    if (!BusinessObject.BODataPool.ContainsKey(id))
                //    {
                //        BusinessObject bo = BOFactory.GetBO(id);
                //        BusinessObject.BODataPool[id] = bo.GetDataList();
                //    }
                //}
                
            }
            return m_dataList;
        }
        public virtual void SetDataList(IList list)
        {
            m_newDataList = list;

        }
        public virtual void SetDataList(IList list, IList removedList)
        {
            m_newDataList = list;
            m_removedDataList = removedList;
        }
        public virtual void SetRemovedDataList(IList list)
        {
            m_removedDataList = list;
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
                        case JTokenType.Array:
                            if (tPro.PropertyType.IsGenericType)
                            {
                                Type t = tPro.PropertyType.GetGenericArguments()[0];
                                if(t == typeof(int))
                                {
                                    tPro.SetValue(result, pro.Value.Select(x => int.Parse(x.ToString())).ToList(), null);
                                }
                            }
                            
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
