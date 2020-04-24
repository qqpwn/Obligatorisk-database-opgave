using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext1
{
    public class ManageFacliteter : IManageFaciliteter
    {
        public const string DBaddress =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ObligatoriskDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Faciliteter> FacilitetList = new List<Faciliteter>();

        public List<Faciliteter> GetAllFacliteter()
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var quertstring = "SELECT * FROM Faciliteter";
                SqlCommand command = new SqlCommand(quertstring, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int faciliteteid = reader.GetInt32(0);
                    string facilitetenavn = reader.GetString(1);
                    TimeSpan facilitetåbningstid = reader.GetTimeSpan(2);
                    TimeSpan facilitetlukketid = reader.GetTimeSpan(3);
                    //int hotel_nr = reader.GetInt32(4);

                    Faciliteter addFaciliteter = new Faciliteter() { Faclitet_Nr = faciliteteid, Navn = facilitetenavn, Åbningstid = facilitetåbningstid, Lukketid = facilitetlukketid/*, Hotel_Nr = hotel_nr*/ };
                    FacilitetList.Add(addFaciliteter);
                }
                connection.Close();
                return FacilitetList;
            }
        }

        public Faciliteter GetFacliteterFromId(int facilitetId)
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var quertstring = $"SELECT * FROM Faciliteter WHERE Facilitet_Nr = {facilitetId}";
                SqlCommand command = new SqlCommand(quertstring, connection);
                connection.Open();
                Faciliteter testFaciliteter = new Faciliteter();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int faciliteteid = reader.GetInt32(0);
                    string facilitetenavn = reader.GetString(1);
                    TimeSpan facilitetåbningstid = reader.GetTimeSpan(2);
                    TimeSpan facilitetlukketid = reader.GetTimeSpan(3);
                    //int hotel_nr = reader.GetInt32(4);

                    testFaciliteter.Faclitet_Nr = faciliteteid;
                    testFaciliteter.Navn = facilitetenavn;
                    testFaciliteter.Åbningstid = facilitetåbningstid;
                    testFaciliteter.Lukketid = facilitetlukketid;
                    //testFaciliteter.Hotel_Nr = hotel_nr;

                }
                connection.Close();
                return testFaciliteter;
            }
        }

        //,{facilitet.Hotel_Nr}
        public bool CreateFacilitet(Faciliteter facilitet)
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var test = GetAllFacliteter().Contains(facilitet);
                if (!test)
                {
                    var querystring =
                        $"INSERT INTO Faciliteter VALUES ({facilitet.Faclitet_Nr},'{facilitet.Navn}','{facilitet.Åbningstid}','{facilitet.Lukketid}')";
                    SqlCommand command = new SqlCommand(querystring, connection);
                    connection.Open();

                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return test;
            }
        }

        //, Hotel_Nr = {facilitet.Hotel_Nr}
        public bool UpdateFacilitet(Faciliteter facilitet, int facilitetId)
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var test = GetAllFacliteter().Contains(facilitet);
                if (!test)
                {
                    var querystring = $"UPDATE Faciliteter SET Facilitet_Nr = {facilitet.Faclitet_Nr}, Navn = '{facilitet.Navn}', Åbningstid = '{facilitet.Åbningstid}', Lukketid ='{facilitet.Lukketid}' WHERE Facilitet_Nr = {facilitetId}";
                    SqlCommand command = new SqlCommand(querystring, connection);
                    connection.Open();

                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return test;
            }
        }

        public Faciliteter DeleteFacilitet(int facilitetId)
        {
            using (SqlConnection connection = new SqlConnection(DBaddress))
            {
                var test = GetFacliteterFromId(facilitetId);
                if (test != null)
                {
                    var querystring =
                        $"DELETE FROM Faciliteter WHERE Facilitet_Nr = {facilitetId}";
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
