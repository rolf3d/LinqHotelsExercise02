using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEventmaker
{
    class Program
    {
        static void Main(string[] args)
        {
            const string serverUrl = "http://eventws20170324123141.azurewebsites.net/api/events";
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
               new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/events").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var events = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                        foreach (var ev in events)
                        {
                            Console.WriteLine(ev.ToString());
                        }


                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }


            }
        }

    }
}
