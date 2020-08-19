using PHelper;
using UnityEngine;

namespace PUser
{
    public static class UserRepository
    {
        private static User _user;

        public static User _User
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
                SaveLoadHelper.Save("/user", _user);
            }
        }

    }
}
