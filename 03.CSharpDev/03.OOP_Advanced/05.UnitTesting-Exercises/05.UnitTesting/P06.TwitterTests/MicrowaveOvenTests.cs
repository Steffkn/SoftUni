namespace P06.TwitterTests
{
    using Moq;
    using NUnit.Framework;
    using P06.Twitter.Interfaces;
    using P06.Twitter.Models;

    [TestFixture]
    class MicrowaveOvenTests
    {
        [TestCase("qwerty")]
        [TestCase("")]
        public void MicrowaveOvenSendsCorrectMessage(string message)
        {
            var writer = new Mock<IWriter>();
            var server = new Mock<IServer>();
            var client = new MicrowaveOven(writer.Object, server.Object);

            client.WriteToConsole(message);
            writer.Verify(w => w.Write(message));

            client.SendToServer(message);
            server.Verify(w => w.GetMessage(message));
            Assert.Pass();
        }
    }
}
