using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Rainbow
    {

        public class RetrieveMultipleRainbowResponse
        {
            public List<Bloczki> Bloczki { get; set; }
        }

        public class BazoweInformacje
        {

            public string Lokalizacje { get; set; }
            public string OfertaNazwa { get; set; }

            public string OfertaURL { get; set; }

        }


        public class Ceny
        {
            public int CenaZaOsobeAktualna { get; set; }

            public int LiczbaDni { get; set; }

        }

        public class Bloczki
        {
            public BazoweInformacje BazoweInformacje { get; set; }
            public List<Ceny> Ceny { get; set; }

            public DateTime TerminWyjazdu { get; set; }

            public List<string> Zdjecia { get; set; }
        }



    }
}
