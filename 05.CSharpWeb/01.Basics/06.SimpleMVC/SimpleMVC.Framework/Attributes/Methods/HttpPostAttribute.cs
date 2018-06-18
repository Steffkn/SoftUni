namespace SimpleMVC.Framework.Attributes.Methods
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        private string methodName = "POST";

        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == methodName;
        }
    }
}
