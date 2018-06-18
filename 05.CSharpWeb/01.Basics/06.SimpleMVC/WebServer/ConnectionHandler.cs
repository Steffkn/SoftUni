namespace WebServer
{
    using Common;
    using Http;
    using Http.Contracts;
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Http.Response;
    using System.Linq;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IHandleable mvcRequestHandler;

        private readonly IHandleable mvcResourceHandler;

        public ConnectionHandler(Socket client, IHandleable mvcRequestHandler, IHandleable mvcResourceHandler)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(mvcRequestHandler, nameof(mvcRequestHandler));
            CoreValidator.ThrowIfNull(mvcResourceHandler, nameof(mvcResourceHandler));

            this.client = client;
            this.mvcRequestHandler = mvcRequestHandler;
            this.mvcResourceHandler = mvcResourceHandler;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadRequest();

            if (httpRequest != null)
            {
                IHttpResponse httpResponse = await this.HandleRequest(httpRequest);
                byte[] responseBytes = await this.GetResponseBytes(httpResponse);

                var byteSegments = new ArraySegment<byte>(responseBytes);

                await this.client.SendAsync(byteSegments, SocketFlags.None);

                Console.WriteLine($"-----REQUEST-----");
                Console.WriteLine(httpRequest);
                Console.WriteLine($"-----RESPONSE-----");
                Console.WriteLine(httpResponse);
                Console.WriteLine();
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<IHttpResponse> HandleRequest(IHttpRequest request)
        {
            if (request.Path.Contains("."))
            {
                return this.mvcResourceHandler.Handle(request);
            }
            else
            {
                string sessionIdToSend = this.SetRequestSession(request);
                var respose = this.mvcRequestHandler.Handle(request);
                this.SetResposeSession(respose, sessionIdToSend);
                return respose;
            }
        }

        private async Task<byte[]> GetResponseBytes(IHttpResponse response)
        {
            var resposeBytes = Encoding.UTF8.GetBytes(response.ToString()).ToList();
            if (response is FileResponse)
            {
                resposeBytes.AddRange(((FileResponse)response).FileData);
            }

            return resposeBytes.ToArray();
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();

            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }
    }
}
