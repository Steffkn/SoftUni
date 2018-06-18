namespace SimpleMVC.Framework.Interfaces
{
    public interface IRenderable
    {
        // The class implementing that method should be responsible for providing and structuring the content of a response to the server
        string Render();
    }
}
