using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.DataTypes
{
    public class Item
    {
        public int productID { get; private set; }
        public string appName { get; private set; }
        public string productModel { get; private set; }
        public string companyName { get; private set; }
        public string desc { get; private set; }
        public int price { get; private set; }
        public int installPrice { get; private set; }
        public string imgURL  {get ; private set; }
        public int inventory { get; private set; }
        public bool isExist {get; private set;}

        private Item() { }
        public Item(int productID, string appName, string productModel, string companyName, string desc, int price, int installPrice, string imgURL, int inventory, bool isExist)
        {
            this.productID = productID;
            this.appName = appName;
            this.productModel = productModel;
            this.companyName = companyName;
            this.desc = desc;
            this.price = price;
            this.installPrice =installPrice;
            this.imgURL = imgURL;
            this.inventory = inventory;
            this.isExist = isExist;
        }
    }
}