using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Methodeclass testMethoder = new Methodeclass();


            //Denne Methode Henter alle vores Faciliteter når den blir kørt:
            testMethoder.GetAllFaciliteters();

            //Denne Methode henter et facilitet fra et id:
            testMethoder.GetFacilitetFromId(1);

            //Denne methode laver et nyt facilitet "createFacilitet" (Udkommenter de 2 nedstående linjer):
            //Faciliteter createFacilitet = new Faciliteter() { Faclitet_Nr = 6, Lukketid = new TimeSpan(20, 00, 00), Åbningstid = new TimeSpan(09, 00, 00), Navn = "CreateFacilitet" };
            //testMethoder.CreateFacilitet(createFacilitet);

            //Denne methode updater et facilitet via et id (Udkommenter de 2 nedstående linjer) :
            //Faciliteter updateFacilitet = new Faciliteter() { Faclitet_Nr = 4, Navn = "UpdateFacilitet", Åbningstid = new TimeSpan(09, 00, 00), Lukketid = new TimeSpan(20, 00, 00) };
            //testMethoder.UpdateFacilitet(updateFacilitet, 4);

            //Denne methode sletter et facilitet via et id (Udkommenter nedstående linje):
            //testMethoder.DeleteFacilitet(6);


            //Denne Methode Henter alle vores hoteller når den blir kørt:
            testMethoder.GetAllHotels();

            //Denne Methode henter et hotel fra et id:
            testMethoder.GetHotelFromId(1);

            //Denne methode laver et nyt hotel "createhotel" (Udkommenter de 2 nedstående linjer):
            //Hotel createHotel = new Hotel() {Hotel_Nr = 6, Navn = "CreateHotel", Adresse = "CreateHotel" };
            //testMethoder.CreateHotel(createHotel);

            //Denne methode updater et hotel via id (Udkommenter de 2 nedstående linjer):
            //Hotel updateHotel = new Hotel() {Hotel_Nr = 4, Navn = "UpdateHotel", Adresse = "UpdateHotel" };
            //testMethoder.UpdateHotel(4, updateHotel);

            //Denne methode sletter et hotel via et id (Udkommenter nedstående linje):
            //testMethoder.DeleteHotel(6);


            Console.ReadKey();
        }
    }
}
