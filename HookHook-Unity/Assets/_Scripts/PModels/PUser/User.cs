using PItem;
using System;
using System.Collections.Generic;
using UnityEditor.Build;

namespace PUser
{
    [Serializable]
    public class User
    {
        public string Name;
        public int Money;
        public List<Item> Purchased;
        public int Level;
        public Skin currentSkin;
        public Background currentBackground;
        public Rope currentRope;
    }
}