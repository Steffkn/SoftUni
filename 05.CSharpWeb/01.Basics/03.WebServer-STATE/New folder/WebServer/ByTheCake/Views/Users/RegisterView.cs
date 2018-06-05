namespace HTTPServer.ByTheCake.Views
{
    using HTTPServer.Server.Contracts;

    public class RegisterView : IView
    {
        public string View()
        {
            return
                "<body>" +
                "   <form method=\"POST\">" +
                "       Name<br/>" +
                "       <input type=\"text\" name=\"name\" /><br/>" +
                "       <input type=\"submit\" value=\"Submit\" />" +
                "   </form>" +
                "</body>";
        }
    }
}
