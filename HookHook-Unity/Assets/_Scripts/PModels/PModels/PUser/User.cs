using PItem;
using System;
using System.Collections.Generic;

namespace PUser
{
    [Serializable]
    public class User
    {
        public string Name = "Default";
        public int Money = 1000;
        public List<Item> Purchased = new List<Item> {
            new Item {Id=0, Name="Default Skin",Price=0,Category="Skin" },
            new Item {Id=30, Name="Default Background",Price=0,Category="Background" },
            new Item {Id=60, Name="Default Rope",Price=0,Category="Rope" }
        };
        public int Level;
        public int currentLevel;
        public Item currentSkin = new Item { Id = 0, Name = "Default Skin", Price = 0, Category = "Skin" };
        public Item currentBackground = new Item { Id = 30, Name = "Default Background", Price = 0, Category = "Background" };
        public Item currentRope = new Item { Id = 60, Name = "Default Rope", Price = 0, Category = "Rope" };
    }
}