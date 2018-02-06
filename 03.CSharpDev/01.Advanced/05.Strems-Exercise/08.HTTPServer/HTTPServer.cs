using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;

public class HTTPServer
{
    private const int port = 1337;
    private const int buffSize = 4096;
    private const string HTTP_400_Ok = "HTTP/1.1 200 OK\nContent-Type:text\n\n";
    private const string VIEWS_FOLDER = "views";
    private const string ERROR_FILE = "/error";
    private const string INDEX_FILE = "/index";

    public static void Main()
    {
        var tcpListener = new TcpListener(IPAddress.Any, port);
        tcpListener.Start();
        Console.WriteLine("Server listening on port {0}!", port);

        while (true)
        {
            using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
            {
                byte[] request = new byte[4096];
                int readBytes = stream.Read(request, 0, buffSize);
                string requestString = Encoding.UTF8.GetString(request, 0, readBytes);

                int indexOffirstSpace = requestString.IndexOf(' ') + 1;
                int fineNameLenght = requestString.IndexOf(' ', indexOffirstSpace) - indexOffirstSpace;

                string file = requestString.Substring(indexOffirstSpace, fineNameLenght);
                Console.WriteLine(requestString);

                string html = string.Empty;
                if (file.Equals("/"))
                {
                    html = string.Format("{0}{1}", HTTP_400_Ok, File.ReadAllText($"{VIEWS_FOLDER}{INDEX_FILE}.html"));
                }
                else if (file.Equals("/info"))
                {
                    var dateTime = DateTime.UtcNow.ToString("dd MMM yyyy HH:mm:ss");
                    html = string.Format("{0}{1}", HTTP_400_Ok, string.Format(File.ReadAllText($"{VIEWS_FOLDER}{file}.html"), dateTime, Environment.ProcessorCount));
                }
                else if (File.Exists($"{VIEWS_FOLDER}{file}.html"))
                {
                    html = string.Format("{0}{1}", HTTP_400_Ok, File.ReadAllText($"{VIEWS_FOLDER}{file}.html"));
                }
                else
                {
                    html = string.Format("{0}{1}", HTTP_400_Ok, File.ReadAllText($"{VIEWS_FOLDER}{ERROR_FILE}.html"));
                }

                byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                stream.Write(htmlBytes, 0, htmlBytes.Length);
            }
        }
    }
}
