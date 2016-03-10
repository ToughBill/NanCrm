using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class ProductMD:ICopyFrom
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public int Group { get; set; }
        public string Refundrate { get; set; }
        public string Price { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int Texture { get; set; }
        public string Remark { get; set; }
        public List<int> Images { get; set; }

        public ProductMD()
        {
            Code = Name = FName = Refundrate
                = Price = Length = Width = Height
                = Weight = Remark = string.Empty;
            Images = new List<int>();
        }

        public object CopyFrom(object fromObj)
        {
            ProductMD source = (ProductMD)fromObj;
            if (source == null)
            {
                return this;
            }
            this.ID = source.ID;
            this.Code = source.Code;
            this.Name = source.Name;
            this.FName = source.FName;
            this.Group = source.Group;
            this.Refundrate = source.Refundrate;
            this.Price = source.Price;
            this.Length = source.Length;
            this.Width = source.Width;
            this.Height = source.Height;
            this.Weight = source.Weight;
            this.Texture = source.Texture;
            this.Remark = source.Remark;
            this.Images.Clear();
            this.Images.AddRange(source.Images);

            return this;
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

        public override bool OnIsValid()
        {
            ProductMD md = (ProductMD)m_boTable;
            IList list = GetDataList();
            JObject find = list.Cast<JObject>().ToList().Find(x => x.ConvertToTarget<ProductMD>().Code == md.Code);
            if(find != null)
            {
                ReportStatusMessage(new SatusMessageInfo(MessageType.Error, MessageCode.EntryExist, this,"产品 \""+md.Code+"\" 已存在！"));
                return false;
            }
            return true;
        }
    }
}
