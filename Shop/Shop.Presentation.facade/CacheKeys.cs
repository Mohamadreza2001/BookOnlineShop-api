namespace Shop.Presentation.facade
{
    class CacheKeys
    {
        public static string User(long id) => $"user-{id}";
        public static string Product(string slug) => $"user-{slug}";
        public static string UserToken(string hashToken) => $"tok-{hashToken}";
        public static string Categories = "categories";
    }
}
