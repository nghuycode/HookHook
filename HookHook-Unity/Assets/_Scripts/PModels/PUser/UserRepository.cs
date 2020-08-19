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
            Item ret;
            switch (item.Category)
            {
                case "Skin":        
                    ret = _user.currentSkin; 
                    break;
                case "Background":
                    ret = _user.currentBackground;
                    break;
                case "Rope":
                    ret = _user.currentRope;
                    break;
            }
            return ret;
        }
    }
}
