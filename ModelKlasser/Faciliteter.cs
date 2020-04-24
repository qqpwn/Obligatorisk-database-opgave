using System;
using System.Collections.Generic;
using System.Text;

namespace ModelKlasser
{
    public class Faciliteter
    {
        public int Faclitet_Nr { get; set; }
        public string Navn { get; set; }
        public TimeSpan Åbningstid { get; set; }
        public TimeSpan Lukketid { get; set; }
        //public int Hotel_Nr { get; set; }

        

        public override string ToString()
        {
            return $"{nameof(Faclitet_Nr)}: {Faclitet_Nr}, {nameof(Navn)}: {Navn}, {nameof(Åbningstid)}: {Åbningstid}, {nameof(Lukketid)}: {Lukketid}";
        }
        //, {nameof(Hotel_Nr)}: {Hotel_Nr}
    }
}
