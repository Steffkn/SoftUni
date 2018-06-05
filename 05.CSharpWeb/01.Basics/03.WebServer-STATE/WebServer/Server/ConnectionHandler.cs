namespace HttpWebServer.Server
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using HttpWebServer.Server.HTTP.Requests;
    using Server.Handlers;
    using Server.HTTP;
    using Server.HTTP.Contracts;
    using Server.Routing.Contracts;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            var request = await this.ReadRequest();

            if (request != null)
            {
                IHttpContext httpContext = new HttpContext(request);
                IHttpResponse response = new HttpHandler(this.serverRouteConfig).Handle(httpContext);
                ArraySegment<byte> toBytes = new ArraySegment<byte>(Encoding.ASCII.GetBytes(response.Response.ToString()));

                await this.client.SendAsync(toBytes, SocketFlags.None);
                Console.WriteLine("[{0}]{1}{2}", DateTime.Now.ToShortTimeString(), Environment.NewLine, request.ToString());
                Console.WriteLine("[{0}]{1}{2}", DateTime.Now.ToShortTimeString(), Environment.NewLine, response.Response.ToString());
            }
            else
            {
                this.client.Shutdown(SocketShutdown.Both);
            }
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var request = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None);

                if (numBytesRead == 0)
                {
                    break;
                }
                var bytesAsString = Encoding.ASCII.GetString(data.Array, 0, numBytesRead);

                request.Append(bytesAsString);

                if (numBytesRead < 1024)
                {
                    break;
                }
            }

            if (request.Length == 0)
            {
                return null;
            }

            return new HttpRequest(request.ToString());
        }
    }
}
