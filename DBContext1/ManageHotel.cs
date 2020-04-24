using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext1
{
    public class ManageHotel : IManageHotel
    {
        public const string DBaddress = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ObligatoriskDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Hotel> HotelList = new List<Hotel>();

        public List<Hotel> GetAllHotels()
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var quertstring = "SELECT * FROM Hotel";
                SqlCommand command = new SqlCommand(quertstring, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int hotelid = reader.GetInt32(0);
                    string hotelnavn = reader.GetString(1);
                    string hoteladresse = reader.GetString(2);
                    
                    Hotel addHotel = new Hotel() { Hotel_Nr = hotelid, Navn = hotelnavn, Adresse = hoteladresse};
                    HotelList.Add(addHotel);
                }
                connection.Close();
                return HotelList;
            }
        }

        public Hotel GetHotelFromId(int hotelId)
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var quertstring = $"SELECT * FROM Hotel WHERE Hotel_Nr = {hotelId}";
                SqlCommand command = new SqlCommand(quertstring, connection);
                connection.Open();
                Hotel testHotel = new Hotel();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int hotelid = reader.GetInt32(0);
                    string hotelnavn = reader.GetString(1);
                    string hoteladresse = reader.GetString(2);

                    testHotel.Hotel_Nr = hotelid;
                    testHotel.Navn = hotelnavn;
                    testHotel.Adresse = hoteladresse;

                }
                connection.Close();
                return testHotel;
            }
        }

        public bool CreateHotel(Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var test = GetAllHotels().Contains(hotel);
                if (!test)
                {
                    var querystring =
                        $"INSERT INTO Hotel VALUES ({hotel.Hotel_Nr},'{hotel.Navn}','{hotel.Adresse}')";
                    SqlCommand command = new SqlCommand(querystring, connection);
                    connection.Open();

                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return test;
            }
        }

        public bool UpdateHotel(int hotelId, Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var test = GetAllHotels().Contains(hotel);
                if (!test)
                {
                    var querystring = $"UPDATE Hotel SET Navn = '{hotel.Navn}', Adresse = '{hotel.Adresse}' WHERE Hotel_Nr = {hotelId}";
                    SqlCommand command = new SqlCommand(querystring, connection);
                    
                    connection.Open();

                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return test;
            }
        }

        public Hotel DeleteHotel(int hotelId)
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var test = GetHotelFromId(hotelId);
                if (test != null)
                {
                    var querystring =
                        $"DELETE FROM Hotel WHERE Hotel_Nr = {hotelId}";
                    SqlCommand command = new SqlCommand(querystring, connection);
                    connection.Open();

                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return test;
            }
        }
    }
}
