﻿using PHelper;
using UnityEngine;

namespace PShop
{
    class ShopRepository
    {
        private static Shop _shop;
        public static Shop Shop
        {
            get {
                if (_shop == null)
                {
                    _shop = new Shop();
                }
                SaveLoadHelper.Save("/shop", _shop);
                return _shop;
            }
            set {
                _shop = value;
            }
        }
    }
}
