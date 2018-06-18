namespace WebServer.Contracts
{
    using Http.Contracts;

    public interface IHandleable
    {
        // The class implementing this interface would be responsible to transform a HTTP request to HTTP response. 
        IHttpResponse Handle(IHttpRequest request);
    }
}
