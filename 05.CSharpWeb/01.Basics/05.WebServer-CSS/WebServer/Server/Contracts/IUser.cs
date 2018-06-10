namespace HTTPServer.Server.Contracts
{
    public interface IUserPrincipal
    {
        int Id { get; }

        string Email { get; }

        bool IsAuthenticated { get; }
    }
}
