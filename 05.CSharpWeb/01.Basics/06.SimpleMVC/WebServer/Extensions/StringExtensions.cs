namespace WebServer.Extensions
{
    using System;

    public static class StringExtensions
    {
        /// <summary>
        /// Returns the input string with the first character converted to uppercase
        /// </summary>
        public static string ToUpperFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("There is no first letter");
            }

            char[] newString = input.ToCharArray();
            newString[0] = char.ToUpper(newString[0]);
            return new string(newString);
        }
    }
}
