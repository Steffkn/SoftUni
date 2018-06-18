namespace SimpleMVC.Framework.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        private string methodName = "GET";

        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == methodName;
        }
    }
}
