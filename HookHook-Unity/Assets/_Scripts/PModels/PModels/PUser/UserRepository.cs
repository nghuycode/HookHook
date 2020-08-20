using PHelper;
using PItem;
using UnityEngine;

namespace PUser
{
    public static class UserRepository
    {
        private static User _user;

        public static User User
        {
            get {
                if (_user == null)
                {
                    string data = SaveLoadHelper.Load("/user");
                    if (data != null)
                    {
                        _user = JsonUtility.FromJson<User>(data);
                    }
                    else
                    {
                        _user = new User();
                    }
                }
                Save();
                return _user;
            }
            set {
                _user = value;
                Save();
            }
        }

        private static void Save()
        {
            SaveLoadHelper.Save("/user", _user);
        }

        public static void AddMoney(int money)
        {
            User.Money += money;
            Save();
        }
        public static bool Buy(Item item)
        {
            if (User.Money >= item.Price)
            {
                User.Money -= item.Price;
                User.Purchased.Add(item);
                Save();
                return true;
            }
            return false;
        }

        public static Item Select(Item item)
        {
            Item ret = new Item();
            switch (item.Category)
            {
                case "Skin":        
                    ret = User.currentSkin;
                    User.currentSkin = item;
                    Save();
                    break;
                case "Background":
                    ret = User.currentBackground;
                    User.currentBackground = item;
                    Save();
                    break;
                case "Rope":
                    ret = User.currentRope;
                    User.currentRope = item;
                    Save();
                    break;
            }
            return ret;
        }
    }
}
