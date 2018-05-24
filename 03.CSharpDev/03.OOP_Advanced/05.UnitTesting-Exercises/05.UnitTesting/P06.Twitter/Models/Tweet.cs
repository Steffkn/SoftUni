namespace P06.Twitter.Models
{
    using P06.Twitter.Interfaces;

    public class Tweet : ITweet
    {
        private string message;

        public Tweet(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return this.message;
        }
    }
}
