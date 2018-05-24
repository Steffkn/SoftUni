namespace P06.Twitter.Models
{
    using P06.Twitter.Interfaces;

    public class MicrowaveOven : IClient
    {
        public MicrowaveOven(IWriter writer, IServer server)
        {
            this.Writer = writer;
            this.Server = server;
        }

        public IWriter Writer { get; }
        public IServer Server { get; }

        public void SendToServer(string message)
        {
            this.Server.GetMessage(message);
        }

        public void WriteToConsole(string message)
        {
            this.Writer.Write(message);
        }
    }
}
