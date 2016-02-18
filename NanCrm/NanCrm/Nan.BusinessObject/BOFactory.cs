using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nan.BusinessObjects.BO;

namespace Nan.BusinessObjects
{
    public class BOFactory
    {
        public static BusinessObject GetBO(BOIDEnum boid)
        {
            BusinessObject bo = null;
            switch (boid)
            {
                case BOIDEnum.BOSequence:
                    bo = new BOSequence();
                    break;
                case BOIDEnum.Country:
                    bo = new BOCountry();
                    break;
                case BOIDEnum.Market:
                    bo = new BOMarket();
                    break;
                case BOIDEnum.MarketDetail:
                    bo = new BOMarketDetail();
                    break;
                case BOIDEnum.Product:
                    bo = new BOProduct();
                    break;
                case BOIDEnum.Texture:
                    bo = new BOTexture();
                    break;
                default: break;
            }
            bo.Init();
            return bo;
        }
    }
}
