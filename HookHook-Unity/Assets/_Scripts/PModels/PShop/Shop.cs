using PHelper;
using PItem;
using System.Collections.Generic;
using UnityEngine;


namespace PShop
{
    public class Shop
    {
        public List<Item> Items = new List<Item>();
        public Shop()
        {
            string tmp = SaveLoadHelper.Load("/shop");
            if (tmp != null)
                Items = JsonUtility.FromJson<ShopSaveModel>(tmp).items;
            else
                Save();
        }

        private void Save()
        {
            SaveLoadHelper.Save("/shop", new ShopSaveModel() { items = Items });
        }
    }
}
