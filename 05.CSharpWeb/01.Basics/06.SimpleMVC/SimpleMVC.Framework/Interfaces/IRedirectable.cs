namespace SimpleMVC.Framework.Interfaces
{
    /// <summary>
    /// This interface will help us create another type of View which is for the Redirect functionality. 
    /// </summary>
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; }
    }
}
