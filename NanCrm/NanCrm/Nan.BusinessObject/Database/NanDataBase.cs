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
        }

        public static NanDataBase GetInstance()
        {
            return m_gNanDBConn;
        }
        public static void InitDatabase(string dbPath, string dbName)
        {
            m_gNanDBConn = new NanDataBase(dbPath, dbName);
        }

        public IList GetTableData(string tbName)
        {
            IList list = new List<JObject>();
            string filePath = Path.Combine(Path.Combine(m_dbPath, m_dbName),tbName);
            if (!File.Exists(filePath))
            {
                return list;
            }
            var json = File.ReadAllText(filePath);
            list = (IList)JsonConvert.DeserializeObject(json);

            return list;
        }
        public bool SaveTableData(string tbName,IList dataList)
        {
            bool result = true;
            try
            {
                string filePath = Path.Combine(Path.Combine(m_dbPath, m_dbName), tbName);
                using (var outstream = new StreamWriter(filePath))
                {
                    var writer = new JsonTextWriter(outstream);
                    var serializer = JsonSerializer.CreateDefault();
                    serializer.Serialize(writer, dataList);
                    outstream.Close();
                }
            }
            catch(Exception e)
            {
                result = false;
            }

            return result;
        }
    }
}
