namespace SimpleMVC.Framework.ActionResults
{
    using SimpleMVC.Framework.Interfaces;

    /// <summary>
    /// A normal string content view result, which can be used to compose a ContentResponse.
    /// </summary>
    public class ViewResult : IViewable
    {
        public ViewResult(IRenderable view)
        {
            this.View = view;
        }

        public IRenderable View { get; set; }

        public string Invoke()
        {
            return this.View.Render();
        }
    }
}
