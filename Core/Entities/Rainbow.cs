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
            public int GwiazdkiHotelu { get; set; }
            public int HappyHoursKolejnosc { get; set; }
            public int HotelID { get; set; }
            public int ImprezaID { get; set; }
            public string Lokalizacje { get; set; }
            public object NazwaHoteluWWW { get; set; }
            public string OfertaNazwa { get; set; }
            public string OfertaURL { get; set; }
            public string OfertaURLDlaGoogle { get; set; }
            public string TypWycieczki { get; set; }
        }

        public class CenyZaPokoj
        {
            public int Cena { get; set; }
            public int CenaPrzedPromocja { get; set; }
            public string Nazwa { get; set; }
            public int WiekDo { get; set; }
            public int WiekOd { get; set; }
        }

        public class Ceny
        {
            public int CenaAktualna { get; set; }
            public int CenaPrzedPromocja { get; set; }
            public int CenaZaOsobeAktualna { get; set; }
            public int CenaZaOsobePrzedPromocja { get; set; }
            public List<CenyZaPokoj> CenyZaPokoj { get; set; }
            public string IataPowrotu { get; set; }
            public string IataWyjazdu { get; set; }
            public int LiczbaDni { get; set; }
            public object LiczbaDniNaPrzedluzeniu { get; set; }
            public int LiczbaDostepnychPokoi { get; set; }
            public string NazwaPromocji { get; set; }
            public string PakietId { get; set; }
            public int ProcentPromocji { get; set; }
            public object PromocjaId { get; set; }
        }

        public class Pionowo
        {
            public bool CzyPokazywac { get; set; }
            public bool CzyUzupelnic { get; set; }
            public string KolorObramowaniaHex { get; set; }
            public string KolorTekstuHex { get; set; }
            public string KolorTlaHex { get; set; }
            public string Nazwa { get; set; }
            public string Opis { get; set; }
            public int WielkoscCzcionki { get; set; }
        }

        public class Poziomo
        {
            public bool CzyPokazywac { get; set; }
            public bool CzyUzupelnic { get; set; }
            public string KolorObramowaniaHex { get; set; }
            public string KolorTekstuHex { get; set; }
            public string KolorTlaHex { get; set; }
            public string Nazwa { get; set; }
            public string Opis { get; set; }
            public int WielkoscCzcionki { get; set; }
        }

        public class Fiszki
        {
            public List<Pionowo> Pionowo { get; set; }
            public List<Poziomo> Poziomo { get; set; }
        }



        public class Przystanki
        {
            public bool CzyDreamliner { get; set; }
            public bool CzySamolot { get; set; }
            public string Iata { get; set; }
            public string Miasto { get; set; }
            public string MiastoURL { get; set; }
            public string Nazwa { get; set; }
        }

        public class PrzystankiPowrotne
        {
            public string WAW { get; set; }
        }

        public class Wyzywienia
        {
            public string Nazwa { get; set; }
            public string URL { get; set; }
        }

        public class Bloczki
        {
            public BazoweInformacje BazoweInformacje { get; set; }
            public string BloczekId { get; set; }
            public List<Ceny> Ceny { get; set; }
            public bool CzyCenaZaWszystkich { get; set; }
            public bool CzyObowiazkowePrzedluzenie { get; set; }
            public Fiszki Fiszki { get; set; }
            public List<object> HoteleNaPrzedluzenie { get; set; }

            public List<Przystanki> Przystanki { get; set; }
            public PrzystankiPowrotne PrzystankiPowrotne { get; set; }
            public string Teaser { get; set; }
            public DateTime TerminWyjazdu { get; set; }
            public List<Wyzywienia> Wyzywienia { get; set; }
            public List<string> Zdjecia { get; set; }
        }



    }
}
