using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppharborAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var delay = TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["delay"]));
            var urls = ConfigurationManager.AppSettings.AllKeys.Where(x=> x.StartsWith("site")).Select(x => ConfigurationManager.AppSettings[x]).ToList();
            while (true)
            {
                foreach (var url in urls)
                {
                    try
                    {
                        client.DownloadString(new Uri(url));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Thread.Sleep(delay);
            }
        }
    }
}
