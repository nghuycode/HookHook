using PItem;
using System.Collections.Generic;

namespace PUser
{
    public class UserSaveModel
    {
        public string Name;
        public int Money;
        public List<Item> Purchased;
        public int Level;
        public List<Item> Equipped;
    }
}
