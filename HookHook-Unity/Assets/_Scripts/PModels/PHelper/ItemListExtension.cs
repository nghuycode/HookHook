using PItem;
using System.Collections.Generic;
using System.Linq;

namespace PHelper
{
    static class ItemListExtension
    {
        public static List<Item> GetBackgrounds(this List<Item> items)
        {
            List<Item> Neww = items.Where(item => item.Category == "Background").ToList();
            return Neww;
        }

        public static List<Item> GetRopes(this List<Item> items)
        {
            List<Item> Neww = items.Where(item => item.Category == "Rope").ToList();
            return Neww;
        }

        public static List<Item> GetSkins(this List<Item> items)
        {
            List<Item> Neww = items.Where(item => item.Category == "Skin").ToList();
            return Neww;
        }
    }
}
