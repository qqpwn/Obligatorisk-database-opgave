using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext1
{
    public interface IManageHotel
    {
        List<Hotel> GetAllHotels();

        Hotel GetHotelFromId(int hotelId);

        bool CreateHotel(Hotel hotel);

        bool UpdateHotel(int hotelId, Hotel hotel);

        Hotel DeleteHotel(int hotelId);
    }
}
