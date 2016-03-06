using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class KeyWordMD
    {
        public int      ID { get; set; }
        [BOFieldAttribute(CFL=true,Desc="关键字")]
        public string   Name { get; set; }

        public KeyWordMD()
        {
            Name = string.Empty;
        }
    }
    [BOAttribute(Name = "关键字")]
    public class BOKeyWord : BusinessObject
    {
        public BOKeyWord()
        {
            base.m_boId = BOIDEnum.KeyWord;
            m_boTable = new KeyWordMD();
        }
        public override bool Init()
        {
            KeyWordMD kwMd = (KeyWordMD)m_boTable;
            kwMd.ID = GetNextID();

            return base.Init();
        }

        public override bool GetById(int id)
        {
            m_boTable = m_dbConn.GetTableData(GetTableName(), id).ConvertToTarget<KeyWordMD>();

            return m_boTable == null;
        }

        public override bool OnIsValidBatch()
        {
            bool result = true;
            if(base.m_removedDataList!=null && base.m_removedDataList.Count>0)
            {
                BOKWList kwlBo = (BOKWList)BOFactory.GetBO(BOIDEnum.KeyWordList);
                List<KWListMD> kwlMdList = kwlBo.GetDataList().Cast<JObject>().Select(x => x.ConvertToTarget<KWListMD>()).ToList();
                foreach(var temp in m_removedDataList)
                {
                    KeyWordMD md = (KeyWordMD)temp;
                    KWListMD kwlMd = kwlMdList.Find(x => x.KeyWrodIds.Contains(md.ID));
                    if (kwlMd != null)
                    {
                        result = false;
                        ReportStatusMessage(new SatusMessageInfo(MessageType.Error, MessageCode.RefenenceError,this,
                            "删除失败！关键字 \"" + md.Name+"\" 在关键字列表 \""+ kwlMd.Name+"\" 中被引用！"));
                        break;
                    }
                }
            }
            return result;
        }
    }
}
