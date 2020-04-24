using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext1
{
    public interface IManageFaciliteter
    {
        List<Faciliteter> GetAllFacliteter();

        Faciliteter GetFacliteterFromId(int facilitetId);

        bool CreateFacilitet(Faciliteter facilitet);

        bool UpdateFacilitet(Faciliteter facilitet, int facilitetId);

        Faciliteter DeleteFacilitet(int facilitetId);
    }
}
