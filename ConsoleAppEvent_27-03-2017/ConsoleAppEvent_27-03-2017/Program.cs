using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEvent_27_03_2017
{
    class Program
    {
        static void Main(string[] args)
        {
            // Den faste forbindelse til serveren
            const string serverUrl = "http://eventwsrolf.azurewebsites.net";


            // ----------------------------------- INDSÆT NY EVENT -------------------------------------
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                var MyNewEvent = new Event()
                {
                    DateTime = new DateTime(2017, 06, 12),
                    description = "En ny fed Event",
                    id = 3,
                    name = "På vandet",
                    place = "i en båd på vandet",
                };
                try
                {
                    var response = client.PostAsJsonAsync<Event>("Api/events", MyNewEvent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har indsæt en ny event");
                        Console.WriteLine("Post Content: " + response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        Console.WriteLine("Fejl, Event blev ikke indsat");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }



            }

            // -------------------------------------- SLET EN EVENT--------------------------------
            //using ( var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(serverUrl);
            //    client.DefaultRequestHeaders.Clear();

            //    string urlString = "Api/events/3";
            //    try
            //    {
            //        HttpResponseMessage response = client.DeleteAsync(urlString).Result;

            //        if (response.IsSuccessStatusCode)
            //        {
            //            Console.WriteLine("Du har slettet en event");
            //            Console.WriteLine("Statuskode : " + response.StatusCode);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Fejl, Eventen blev ikke slettet");
            //            Console.WriteLine("Statuskode  :" + response.StatusCode);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Der er sket en fejl : " + e.Message);
            //    }



            //}

            // ----------------------------------------------- OPDATER EN EVENT --------------------------------------------
            using (var client = new HttpClient())
            {
               client.BaseAddress = new Uri(serverUrl);
               client.DefaultRequestHeaders.Clear();

               var MyUpdatedEvent = new Event()
               {
                   DateTime = new DateTime(2017, 06, 12),
                   description = "En ny fed Event",
                   id = 2,
                   name = "På vandet",
                   place = "i en båd på vandet",
               };

                MyUpdatedEvent.name = "På Månen";
                try
                {
                    var response = client.PutAsJsonAsync("Api/events/2", MyUpdatedEvent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har opdxateret en event");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("Fejl, Eventen blev ikke opdateret");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
                


            }

            // behøver ikke at lave en liste. Det laves i if sætningen i response.
            //List<Event> mineventliste = new List<Event>();

            // ------------------------------------------------- HENT ALT FRA EVENT TABELLEN ------------------------------------
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);

                client.DefaultRequestHeaders.Clear();
                // prøver at smide det ud som xml
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlString = "Api/events";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;

                    if (response.IsSuccessStatusCode)


                    {
                        // Hvis man ikke havde List med i response kunne man skrive det således.
                        //mineventliste = response.Content.ReadAsAsync<IEnumerable<Event>>().Result as List<Event>;
                        var mineventliste = response.Content.ReadAsAsync<List<Event>>().Result;


                        foreach (var ev in mineventliste)
                        {
                            Console.WriteLine("Event id : " + ev.id + " Event Name : " + ev.name + " Place: " + ev.place + " Description: " + ev.description + " Date: " + ev.DateTime);
                        }

                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }
            
            Console.ReadLine();
              
            return;
            
            Console.ReadLine();
        }
    }
}
