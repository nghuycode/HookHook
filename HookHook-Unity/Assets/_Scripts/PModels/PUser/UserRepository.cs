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
            _user.Money += money;
            Save();
        }
        public static bool Buy(Item item)
        {
            if (_user.Money >= item.Price)
            {
                _user.Money -= item.Price;
                _user.Purchased.Add(item);
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
                    ret = _user.currentSkin;
                    _user.currentSkin = item;
                    Save();
                    break;
                case "Background":
                    ret = _user.currentBackground;
                    _user.currentBackground = item;
                    Save();
                    break;
                case "Rope":
                    ret = _user.currentRope;
                    _user.currentRope = item;
                    Save();
                    break;
            }
            return ret;
        }
    }
}
