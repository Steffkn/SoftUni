using System.Text.RegularExpressions;

namespace SimpleMVC.Framework.Attributes.Properties
{
    public class RegexAttribute : PropertyAttribute
    {
        private readonly string pattern;

        public RegexAttribute(string pattern)
        {
            this.pattern = "^" + pattern + "$";
        }

        public override bool IsValid(object value)
        {
            return Regex.IsMatch(value.ToString(), this.pattern);
        }
    }
}
