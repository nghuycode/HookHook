namespace PShop
{
    public static class ShopRepository
    {
        private static Shop _shop;
        public static Shop Shop
        {
            get {
                if (_shop == null)
                {
                    _shop = new Shop();
                }
                return _shop;
            }
            set {
                _shop = value;
            }
        }
    }
}
