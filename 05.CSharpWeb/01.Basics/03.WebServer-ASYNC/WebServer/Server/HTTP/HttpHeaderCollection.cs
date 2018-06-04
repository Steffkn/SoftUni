namespace HttpWebServer.Server.HTTP
{
    using System.Collections.Generic;
    using Server.HTTP.Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (!this.headers.ContainsKey(header.Key))
            {
                this.headers.Add(header.Key, header);
            }
            else
            {
                this.headers[header.Key] = header;
            }
        }

        public bool ContainsKey(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (!this.headers.ContainsKey(key))
            {
                return null;
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            return string.Join("\n", this.headers.Values);
        }
    }
}
