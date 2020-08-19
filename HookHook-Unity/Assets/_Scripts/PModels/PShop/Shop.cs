using PItem;
using System;
using System.Collections.Generic;


namespace PShop
{
    [Serializable]
    public class Shop
    {
        public List<Item> Items = new List<Item> {
            new Item {Id=0, Name="Default",Price=0,Category="Skin" },
            new Item {Id=1, Name="",Price=300,Category="Skin" },
            new Item {Id=2, Name="",Price=100,Category="Skin" },
            new Item {Id=3, Name="",Price=500,Category="Skin" },
            new Item {Id=4, Name="",Price=0,Category="Skin" },
            new Item {Id=5, Name="",Price=0,Category="Skin" },

            new Item {Id=0, Name="",Price=450,Category="Background" },
            new Item {Id=1, Name="",Price=200,Category="Background" },
            new Item {Id=2, Name="",Price=0,Category="Background" },
            new Item {Id=3, Name="",Price=0,Category="Background" },
            new Item {Id=4, Name="",Price=0,Category="Background" },
            new Item {Id=5, Name="",Price=0,Category="Background" },

            new Item {Id=0, Name="",Price=140,Category="Rope" },
            new Item {Id=1, Name="",Price=540,Category="Rope" },
            new Item {Id=2, Name="",Price=0,Category="Rope" },
            new Item {Id=3, Name="",Price=0,Category="Rope" },
            new Item {Id=4, Name="",Price=0,Category="Rope" },
            new Item {Id=5, Name="",Price=0,Category="Rope" }
        };
    }
}
