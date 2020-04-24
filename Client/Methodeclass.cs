using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace Client
{
    public class Methodeclass
    {
        const string acessstring = "http://localhost:62991/";


        public void GetAllFaciliteters()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Du har hentet alle faciliteter\n");
                try
                {
                    var hentFaciliteter = client.GetAsync("api/faciliteter").Result;
                    if (hentFaciliteter.IsSuccessStatusCode)
                    {
                        var minefaciliteter = hentFaciliteter.Content.ReadAsAsync<IEnumerable<Faciliteter>>().Result;

                        foreach (var facilitere in minefaciliteter)
                        {
                            Console.WriteLine(facilitere);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }

            }
        }

        public void GetFacilitetFromId(int id)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Faciliteter mitFaciliteter = new Faciliteter();

                Console.WriteLine($"\nDu har hentet facilitet med id = {id}\n");
                try
                {
                    var hentFaciliteter = client.GetAsync($"api/faciliteter/{id}").Result;
                    if (hentFaciliteter.IsSuccessStatusCode)
                    {
                        var minefaciliteter = hentFaciliteter.Content.ReadAsAsync<Faciliteter>().Result;

                        mitFaciliteter.Faclitet_Nr = minefaciliteter.Faclitet_Nr;
                        mitFaciliteter.Navn = minefaciliteter.Navn;
                        mitFaciliteter.Åbningstid = minefaciliteter.Åbningstid;
                        mitFaciliteter.Lukketid = minefaciliteter.Lukketid;
                        Console.WriteLine(minefaciliteter);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }


            }
        }

        public void CreateFacilitet(Faciliteter postFacilitet)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var createFacilitet = client.PostAsJsonAsync("api/Faciliteter", postFacilitet).Result;
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }
                Console.WriteLine($"\nDu har created en facilitet\n");
                Console.WriteLine(postFacilitet);
            }

        }


        public void UpdateFacilitet(Faciliteter update, int id)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var createFacilitet = client.PutAsJsonAsync($"api/faciliteter/{id}", update).Result;
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }
                Console.WriteLine($"\nDu har updatet en facilitet\n");
                Console.WriteLine(update);
            }
        }

        public void DeleteFacilitet(int id)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var createFacilitet = client.DeleteAsync($"api/faciliteter/{id}").Result;
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }

                Console.WriteLine($"\nDu har delete en facilitet med id = {id}\n");
            }
        }

        public void GetAllHotels()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Du har hentet alle Hoteller\n");
                try
                {
                    var hentHotels = client.GetAsync("api/hotel").Result;
                    if (hentHotels.IsSuccessStatusCode)
                    {
                        var minehotels = hentHotels.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        foreach (var hotels in minehotels)
                        {
                            Console.WriteLine(hotels);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }

            }
        }
        public void GetHotelFromId(int id)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Hotel mitHotel = new Hotel();

                Console.WriteLine($"\nDu har hentet Hotel med id = {id}\n");
                try
                {
                    var hentHotel = client.GetAsync($"api/hotel/{id}").Result;
                    if (hentHotel.IsSuccessStatusCode)
                    {
                        var mineHotel = hentHotel.Content.ReadAsAsync<Hotel>().Result;

                        mitHotel.Hotel_Nr = mineHotel.Hotel_Nr;
                        mitHotel.Navn = mineHotel.Navn;
                        mitHotel.Adresse = mineHotel.Adresse;
                        
                        Console.WriteLine(mineHotel);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }


            }
        }

        public void CreateHotel(Hotel postHotel)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var createHotel = client.PostAsJsonAsync("api/hotel", postHotel).Result;
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }
                Console.WriteLine($"\nDu har created en Hotel\n");
                Console.WriteLine(postHotel);
            }

        }


        public void UpdateHotel(int id, Hotel update)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine($"\nDu har updatet et Hotel\n");
                try
                {
                    var createHotel = client.PutAsJsonAsync($"api/Hotel/{id}", update).Result;
                    if (createHotel.IsSuccessStatusCode)
                    {
                        Console.WriteLine(update);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }
                
                
            }
        }

        public void DeleteHotel(int id)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(acessstring);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var deleteHotel = client.DeleteAsync($"api/hotel/{id}").Result;
                }
                catch (Exception)
                {
                    Console.WriteLine("Shit dosnt work");

                }

                Console.WriteLine($"\nDu har delete et Hotel med id = {id}\n");
            }
        }
    }
}

