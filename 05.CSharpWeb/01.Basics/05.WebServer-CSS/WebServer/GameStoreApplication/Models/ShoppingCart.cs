namespace HTTPServer.GameStoreApplication.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public const string SessionKey = "%^Current_Shopping_Cart^%";

        public List<GameInfo> Games { get; private set; } = new List<GameInfo>();
    }
}
