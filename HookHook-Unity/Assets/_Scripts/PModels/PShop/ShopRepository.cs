using PHelper;
using UnityEngine;

namespace PShop
{
    class ShopRepository
    {
        public static Shop _shop;
        public static Shop Shop
        {
            get {
                if (_shop == null)
                { 
                    string tmp = SaveLoadHelper.Load("/shop");
                    if (tmp != null)
                        _shop = JsonUtility.FromJson<Shop>(tmp);
                    else
                    {
                        _shop = new Shop();
                    }  
                }
                SaveLoadHelper.Save("/shop", _shop);
                return _shop;
            }
            set {
                _shop = value;
                SaveLoadHelper.Save("/shop", _shop);
            }
        }
    }
}
