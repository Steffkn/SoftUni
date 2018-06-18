namespace SimpleMVC.Framework.Interfaces
{
    public interface IActionResult
    {
        // This interface is mainly used as a return type for the actions of the different controllers. It must always stay at the top of the hierarchy chain because many things depend on it. 
        string Invoke();
    }
}
