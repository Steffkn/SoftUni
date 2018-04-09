namespace P06.Twitter.Interfaces
{
    public interface IClient
    {
        void WriteToConsole(string message);

        void SendToServer(string message);
    }
}
