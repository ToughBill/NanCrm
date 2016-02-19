using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Data.Json;
using Nan.BusinessObjects.BO;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nan.BusinessObjects.Database
{
    public class NanDataBase : JsonDbCore
    {
        private string m_dbPath;
        private string m_dbName;

        private static NanDataBase m_gNanDBConn = null;
        private static readonly object lockHelper = new object();

        public NanDataBase(string dbPath, string dbName):base(dbPath,dbName)
        {
            m_dbPath = dbPath;
            m_dbName = dbName;
            if (!Directory.Exists(Path.Combine(m_dbPath,m_dbName)))
            {
                Directory.CreateDirectory(Path.Combine(m_dbPath, m_dbName));
            }
        }

        public static NanDataBase GetInstance()
        {
            return m_gNanDBConn;
        }
        public static void InitDatabase(string dbPath, string dbName)
        {
            m_gNanDBConn = new NanDataBase(dbPath, dbName);
        }

        public string GetDBPath()
        {
            return Path.Combine(m_dbPath, m_dbName);
        }

        public IList GetTableData(string tbName)
        {
            IList list = new List<JObject>();
            string filePath = Path.Combine(Path.Combine(m_dbPath, m_dbName),tbName);
            if (!File.Exists(filePath))
            {
                return list;
            }
            //var json = File.ReadAllText(filePath);
            //list = (IList)JsonConvert.DeserializeObject(json);
            foreach (string str in Directory.GetFiles(filePath))
            {
                var json = File.ReadAllText(Path.Combine(filePath, str));
                JObject jo = (JObject)JsonConvert.DeserializeObject(json);
                list.Add(jo);
            }

            return list;
        }
        public JObject GetTableData(string tbName, int id)
        {
            string filePath = Path.Combine(Path.Combine(m_dbPath, m_dbName), tbName);
            if (!File.Exists(filePath))
            {
                return null;
            }
            var json = File.ReadAllText(Path.Combine(filePath, id.ToString()));
            JObject jo = (JObject)JsonConvert.DeserializeObject(json);
            
            return jo;
        }
        public bool SaveTableData(string tbName,IList dataList)
        {
            bool result = true;
            try
            {
                string filePath = Path.Combine(Path.Combine(m_dbPath, m_dbName), tbName);
                IEnumerator iter =  dataList.GetEnumerator();
                while (iter.MoveNext())
                {
                    JObject jo = JObject.FromObject(iter.Current);
                    string id = jo.GetValue("ID").ToString();
                    using (var tempStream = new StreamWriter(Path.Combine(filePath,id)))
                    {
                        var writer = new JsonTextWriter(tempStream);
                        var serializer = JsonSerializer.CreateDefault();
                        serializer.Serialize(writer, jo);
                        tempStream.Close();
                    }
                }
                /*using (var outstream = new StreamWriter(filePath))
                {
                    var writer = new JsonTextWriter(outstream);
                    var serializer = JsonSerializer.CreateDefault();
                    serializer.Serialize(writer, dataList);
                    outstream.Close();
                }*/
            }
            catch(Exception e)
            {
                result = false;
            }

            return result;
        }

        public bool SaveTableData(string tbName, object data)
        {
            bool result = true;
            try
            {
                string filePath = Path.Combine(Path.Combine(m_dbPath, m_dbName), tbName);
                JObject jo = JObject.FromObject(data);
                string id = jo.GetValue("ID").ToString();
                using (var tempStream = new StreamWriter(Path.Combine(filePath, id)))
                {
                    var writer = new JsonTextWriter(tempStream);
                    var serializer = JsonSerializer.CreateDefault();
                    serializer.Serialize(writer, jo);
                    tempStream.Close();
                }
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }
}
