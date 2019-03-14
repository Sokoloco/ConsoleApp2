using Nancy;
using Nancy.Bootstrapper;
using Nancy.Extensions;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program : NancyModule
    {

        static void Main(string[] args)
        {

            HostConfiguration hostConfigs = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            var host = new NancyHost(new Uri("http://localhost:12345"), new DefaultNancyBootstrapper(), hostConfigs);
            host.Start(); // start hosting

            Console.ReadKey();
            host.Stop(); // stop hosting
        }


    }
}
