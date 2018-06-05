namespace HttpWebServer.Server.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Enums;
    using Server.Exceptions;
    using Server.HTTP.Contracts;

    public class HttpRequest : IHttpRequest
    {
        private string requestString;

        public HttpRequest(string requestString)
        {
            this.requestString = requestString;
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();
            this.ParseRequest(requestString);
        }

        public Dictionary<string, string> FormData { get; }

        public IHttpHeaderCollection Headers { get; private set; }

        public IHttpCookieCollection Cookies { get; private set; }

        public string Path { get; private set; }

        public Dictionary<string, string> QueryParameters { get; }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; }

        public IHttpSession Session { get; set; }

        public void AddUrlParameter(string key, string value)
        {
            if (!this.UrlParameters.ContainsKey(key))
            {
                this.UrlParameters.Add(key, value);
            }
            else
            {
                this.UrlParameters[key] = value;
            }
        }

        // TODO
        private void ParseCookies()
        {
            if (this.Headers.ContainsKey(HttpHeader.Cookie))
            {
                var allCookies = this.Headers.Get(HttpHeader.Cookie);

                foreach (var cookie in allCookies)
                {
                    if (!cookie.Value.Contains('='))
                    {
                        return;
                    }

                    var cookieParts = cookie
                        .Value
                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    if (!cookieParts.Any())
                    {
                        continue;
                    }

                    foreach (var cookiePart in cookieParts)
                    {
                        var cookieKeyValuePair = cookiePart
                            .Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                        if (cookieKeyValuePair.Length == 2)
                        {
                            var key = cookieKeyValuePair[0].Trim();
                            var value = cookieKeyValuePair[1].Trim();

                            this.Cookies.Add(new HttpCookie(key, value, false));
                        }
                    }
                }
            }
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string[] requestLine = requestLines[0].Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            // TODO: Lenght != 3?
            if (requestLines.Length < 3 || requestLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid request line");
            }

            this.Method = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];
            this.Path = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);
            this.ParseParameters();

            if (this.Method == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
            }
        }

        private HttpRequestMethod ParseRequestMethod(string requestMethod)
        {
            HttpRequestMethod httpRequestMethod;

            if (!Enum.TryParse(requestMethod, out httpRequestMethod))
            {
                throw new BadRequestException("Invalid request method");
            }

            return httpRequestMethod;
        }

        private void ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, string.Empty);
            for (int i = 1; i < endIndex; i++)
            {
                string[] headerArgs = requestLines[i].Split(new[] { ": " }, StringSplitOptions.None);
                string key = headerArgs[0];
                string value = headerArgs[1];
                var header = new HttpHeader(key, value);
                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsKey("Host"))
            {
                throw new BadRequestException("Request does not contain 'Host' header");
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split("?")[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, Dictionary<string, string> queryParameters)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split('&');
            foreach (string queryPair in queryPairs)
            {
                string[] queryArgs = queryPair.Split('=');
                if (queryArgs.Length != 2)
                {
                    continue;
                }

                string queryKey = WebUtility.UrlDecode(queryArgs[0]);
                string queryValue = WebUtility.UrlDecode(queryArgs[1]);
                queryParameters.Add(queryKey, queryValue);
            }
        }

        public override string ToString()
        {
            return this.requestString;
        }
    }
}
