namespace P06.TwitterTests
{
    using Moq;
    using NUnit.Framework;
    using P06.Twitter.Models;

    [TestFixture]
    public class TweetTests
    {
        [TestCase(null)]
        [TestCase("qwerty")]
        [TestCase("")]
        public void GetMessage_CreatedTweetReturnsCorrectMessage(string message)
        {
            var tweet = new Tweet(message);
            Assert.That(tweet.GetMessage(), Is.EqualTo(message));
        }

    }
}
