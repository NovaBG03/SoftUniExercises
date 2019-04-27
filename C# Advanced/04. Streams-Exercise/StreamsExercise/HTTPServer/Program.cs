using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace HTTPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverDirectory = "../../../../Files/HttpServer";

            var server = new HttpListener();

            server.Prefixes.Add("http://127.0.0.1/");
            server.Prefixes.Add("http://localhost:8081/");
            
            server.Start();

            Console.WriteLine("Listening...");

            while (true)
            {
                try
                {
                    var context = server.GetContext(); //Block until a connection comes in
                    var response = context.Response;

                    string page = serverDirectory + context.Request.Url.LocalPath;

                    if (page == $"{serverDirectory}/")
                    {
                        page = $"{serverDirectory}/index.html";
                    }
                    else if(page == $"{serverDirectory}/info")
                    {
                        page += ".html";
                    }
                    else
                    {
                        page = $"{serverDirectory}/error.html";
                    }


                    var buffer = new byte[4096];
                    using (var reader = new StreamReader(page))
                    {
                        while (true)
                        {
                            var readed = reader.ReadLine();

                            if (readed == null)
                            {
                                break;
                            }

                            if (page == $"{serverDirectory}/info.html")
                            {
                                string currentTime = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year} {DateTime.Now.Hour}:{DateTime.Now.Minute:00}";

                                readed = string.Format(readed, currentTime, Process.GetProcesses().Length);
                            }

                            var bits = Encoding.UTF8.GetBytes(readed);

                            response.OutputStream.Write(bits, 0, bits.Length);
                        }
                    }

                    

                }
                catch (Exception)
                {
                    // Client disconnected or some other error - ignored for this example
                }
            }
        }
    }
}

