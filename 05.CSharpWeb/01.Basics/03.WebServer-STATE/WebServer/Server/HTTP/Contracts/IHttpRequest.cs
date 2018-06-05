namespace HttpWebServer.Server.HTTP.Contracts
{
    using System.Collections.Generic;
    using Enums;

    public interface IHttpRequest
    {
        HttpRequestMethod Method { get; }

        Dictionary<string, string> FormData { get; }

        Dictionary<string, string> QueryParameters { get; }

        Dictionary<string, string> UrlParameters { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        string Path { get; }

        string Url { get; }

        IHttpSession Session { get; set; }

        void AddUrlParameter(string key, string value);
    }
}
