﻿namespace HttpWebServer.Server.HTTP.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
            : base(redirectUrl)
        {
        }
    }
}
