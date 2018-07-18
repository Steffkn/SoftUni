using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace BookLibrary.Web.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceCaseInsensitive(this string input, string search, string replacement)
        {
            string result = Regex.Replace(
                input,
                Regex.Escape(search),
                replacement.Replace("$", "$$"),
                RegexOptions.IgnoreCase
            );
            return result;
        }

        public static string SurroundWithTag(this string input, string search, string tag, object htmlAttributes = null)
        {
            string lowerInput = input.ToLower();
            int indexOfSearch = lowerInput.IndexOf(search.ToLower());

            if (indexOfSearch == -1)
            {
                return input;
            }

            string attributes = string.Empty;
            if (htmlAttributes != null)
            {
                var htmlAttrs = new RouteValueDictionary(htmlAttributes);
                attributes = string.Join(" ", htmlAttrs.Select(GetAttribute));
            }

            string result = string.Format("{0}<{1} {4}>{2}</{1}>{3}",
               input.Substring(0, indexOfSearch),
               tag,
               input.Substring(indexOfSearch, search.Length),
               input.Substring(indexOfSearch + search.Length),
               attributes);

            return result;
        }

        private static string GetAttribute(KeyValuePair<string, object> item)
        {
            return string.Format("{0}=\"{1}\"", item.Key, System.Net.WebUtility.HtmlEncode(item.Value.ToString()));
        }
    }
}
