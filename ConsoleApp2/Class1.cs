using Nancy;
using Nancy.Bootstrapper;
using Nancy.Extensions;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Class1 : NancyModule
    {

        string usr = "koppaholis";

        public Class1() : base("/")
        {
            After.AddItemToEndOfPipeline((ctx) => ctx.Response
            .WithHeader("Access-Control-Allow-Origin", "*")
            .WithHeader("Access-Control-Allow-Methods", "GET, POST")
            .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type"));

            string holis = File.ReadAllText("C:\\Users\\fmuri\\source\\repos\\WebApplication1\\WebApplication1\\HtmlPage1.html");

            Get["/"] = _ => "Hello World from Server!";

            Get["/CP"] = _ =>
            {
                string response = File.ReadAllText("C:\\Users\\fmuri\\source\\repos\\WebApplication1\\WebApplication1\\CP.json");

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            };

            Post["/login"] = x =>
            {
                string string2 = this.Request.Body.AsString();
                Console.WriteLine(string2);
                File.WriteAllText("C:\\Users\\fmuri\\source\\repos\\WebApplication1\\WebApplication1\\holis.txt", this.Request.Body.AsString());
                string response ="[]";



                if (string.Compare(usr, string2) == 0)
                {
                    response = "{\"option\" : \"succes\"}";
                    Console.WriteLine("success");
                }
                else
                {
                    response = "{\"option\" : \"failed\"}";
                }

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            };

            Get["/clientes"] = _ =>
            {
                string response = File.ReadAllText("C:\\Users\\fmuri\\source\\repos\\WebApplication1\\WebApplication1\\clientes.json");

                var jsonBytes = Encoding.UTF8.GetBytes(response);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
            };
        }

       

    }
}
