using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Core;

namespace Nan.BusinessObjects.BO
{
    public class SequenceMD
    {
        [PrimaryKeyAttribute(false)]
        public int BOID { get; set; }
        public int NextID { get; set; }
    }

    public class BOSequence : BusinessObject
    {
        private SequenceMD m_seqMD;
        public BOSequence()
        {
            base.m_boId = BOIDEnum.BOSequence;
            m_seqMD = new SequenceMD();
        }

        public override bool Init()
        {
            return true;
        }
    }
}
