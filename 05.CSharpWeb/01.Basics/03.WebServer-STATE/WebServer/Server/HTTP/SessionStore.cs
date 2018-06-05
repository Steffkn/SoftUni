namespace HttpWebServer.Server.HTTP
{
    using System.Collections.Concurrent;

    public static class SessionStore
    {
        public const string SessionCookieKey = "MY_SID";

        public const string CurrentUserKey = "^%Current_User_Session_Key%^";

        private static readonly ConcurrentDictionary<string, HttpSession> sessions = new ConcurrentDictionary<string, HttpSession>();

        public static HttpSession Get(string id)
        {
            return sessions.GetOrAdd(id, func => new HttpSession(id));
        }
    }
}
