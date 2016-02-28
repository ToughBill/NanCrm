using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace Nan.BusinessObjects.BO
{
    public class TextureMD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public TextureMD()
        {
            Name = Desc = string.Empty;
        }
    }

    public class BOTexture : BusinessObject
    {
        private TextureMD m_boTexture;
        public BOTexture()
        {
            base.m_boId = BOIDEnum.Texture;
            m_boTexture = new TextureMD();
        }

        public override bool Init()
        {
            m_boTexture.ID = GetNextID();

            return base.Init();
        }

    }
}
