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
    }
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
    }
}
