using Assets.Scripts.PModels.PUser;
using Assets.Scripts.PModels.Shop;

namespace PModels
{
    public class DataRepository
    {
        static Shop shop;
        static User user;

        public static Shop Shop
        {
            get
            {
                if (shop == null)
                    shop = new Shop();
                return shop;
            }
        }

        public static User User
        {
            get
            {
                if (user == null)
                    user = new User();
                return user;
            }
        }
    }
}
