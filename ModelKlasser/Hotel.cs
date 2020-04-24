using System;
using System.Collections.Generic;
using System.Text;

namespace ModelKlasser
{
   public class Hotel
    {
        public int Hotel_Nr { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }

        public Hotel()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(Hotel_Nr)}: {Hotel_Nr}, {nameof(Navn)}: {Navn}, {nameof(Adresse)}: {Adresse}";
        }
    }
}
