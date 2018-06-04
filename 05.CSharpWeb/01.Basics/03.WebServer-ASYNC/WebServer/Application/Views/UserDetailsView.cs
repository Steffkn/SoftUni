namespace HttpWebServer.Application.Views
{
    using HttpWebServer.Server;
    using HttpWebServer.Server.Contracts;

    public class UserDetailsView : IView
    {
        private Model model;

        public UserDetailsView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            return $"<body>Hello, {model["name"]}!<body/>";
        }
    }
}
