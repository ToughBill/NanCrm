using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class ProductMD
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public int Category { get; set; }
        public string Refundrate { get; set; }
        public string Price { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int Texture { get; set; }
        public string Remark { get; set; }

        public ProductMD()
        {
            Code = Name = FName = Refundrate
                = Price = Length = Width = Height
                = Weight = Remark = string.Empty;
        }
    }
    public class BOProduct : BusinessObject
    {
        public BOProduct()
        {
            base.m_boId = BOIDEnum.Product;
            m_boTable = new ProductMD();
        }

//         public override object GetBOTable()
//         {
//             return boPro;
//         }

        public override bool Init()
        {
            base.Init();
            ProductMD boPro = (ProductMD)m_boTable;
            boPro.ID = GetNextID();
            

            return true;
        }
    }
}
