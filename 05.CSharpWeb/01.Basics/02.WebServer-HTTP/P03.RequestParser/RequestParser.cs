using System.Collections.Generic;

namespace P03.RequestParser
{
    using System;

    public class RequestParser
    {
        private static string HttpResponseHeader = "HTTP/1.1 {0}\nContent-Length: {1}\nContent-Type: text/plain\n\n{2}";
        private static Dictionary<int, string> StatusTextByResponseCode = new Dictionary<int, string>
        {
            {200,"OK"},
            {404,"Not Found"}
        };
        private static Dictionary<string, HashSet<string>> ValidActions = new Dictionary<string, HashSet<string>>();

        static void Main()
        {
            GetValidActions();
            string httpRequest = Console.ReadLine();
            string httpResponce = GetHttpResponce(httpRequest);
            Console.WriteLine(httpResponce);
        }

        private static string GetHttpResponce(string httpRequest)
        {
            var requestParams = httpRequest.Split(new[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
            var method = requestParams[0].ToLower();
            if (method != "get" && method != "post")
            {
                return GetStatusMessage(404);
            }

            var path = requestParams[1];
            var protocol = requestParams[2];
            var version = requestParams[3];

            if (ValidActions.ContainsKey(path) && ValidActions[path].Contains(method))
            {
                return GetStatusMessage(200);
            }

            return GetStatusMessage(404);
        }

        private static string GetStatusMessage(int statusCode)
        {
            return string.Format(HttpResponseHeader, $"{statusCode} {StatusTextByResponseCode[statusCode]}", StatusTextByResponseCode[statusCode].Length, StatusTextByResponseCode[statusCode]);
        }

        private static void GetValidActions()
        {
            string currentPath = string.Empty;

            while ((currentPath = Console.ReadLine()).ToUpper() != "END")
            {
                string[] pathArgs = currentPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string path = pathArgs[0];
                string method = pathArgs[1];

                if (!ValidActions.ContainsKey(path))
                {
                    ValidActions.Add(path, new HashSet<string>());
                }

                ValidActions[path].Add(method.ToLower());
            }
        }
    }
}
