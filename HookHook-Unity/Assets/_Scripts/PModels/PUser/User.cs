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
            new Item {Id=0, Name="",Price=0,Category="Skin" },
            new Item {Id=0, Name="",Price=0,Category="Background" },
            new Item {Id=0, Name="",Price=0,Category="Rope" }
        };
        public int Level;
        public int currentLevel;
        public Skin currentSkin = new Skin { Id = 0, Name = "Default"};
        public Background currentBackground = new Background { Id = 0,Name = "Default"};
        public Rope currentRope = new Rope {Id = 0,Name = "Default" };
    }
}