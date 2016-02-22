using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class ProductGroupMD
    {
        public int      ID { get; set; }
        public string   Name { get; set; }
        public string   Desc { get; set; }

        public ProductGroupMD()
        {
            Name = Desc = string.Empty;
        }
    }

    [BOAttribute(Name = "产品分组")]
    public class BOProductGroup : BusinessObject
    {
        public BOProductGroup()
        {
            base.m_boId = BOIDEnum.ProductGroup;
            m_boTable = new ProductGroupMD();
        }

        public override bool Init()
        {
            ProductGroupMD proGrp = (ProductGroupMD)m_boTable;
            proGrp.ID = GetNextID();

            return base.Init();
        }

        public override bool OnIsValid()
        {
            bool isValid = true;
            if (m_boTable != null)
            {
                ProductGroupMD proGrp = (ProductGroupMD)m_boTable;
                if (string.IsNullOrEmpty(proGrp.Name))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public override bool GetById(int id)
        {
            ProductGroupMD mkt = m_dbConn.GetTableData(GetTableName(), id).ConvertToTarget<ProductGroupMD>();
            m_boTable = mkt;

            return m_boTable == null;
        }
    }
}
