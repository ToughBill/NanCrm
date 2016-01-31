using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class TextureTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }

    public class BOTexture : BusinessObject
    {
        private TextureTable m_boTexture;
        public BOTexture()
        {
            base.m_boId = BOIDEnum.Market;
            m_boTexture = new TextureTable();
        }

        public override bool Init()
        {
            m_boTexture.ID = GetNextID();

            return base.Init();
        }
    }
}
