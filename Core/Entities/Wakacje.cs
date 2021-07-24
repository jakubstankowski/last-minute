using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Wakacje
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

        public class RetrieveMultipleWakacjeResponse
        {
            public Data data { get; set; }
        }

        public class Offer
        {

            public string name { get; set; }
            public string placeName { get; set; }
            public string link { get; set; }
            public string photo { get; set; }
            public int price { get; set; }
            public int duration { get; set; }
            public string departureDate { get; set; }
            public string returnDate { get; set; }
            public string serviceDesc { get; set; }
        }



        public class Data
        {
            public List<Offer> offers { get; set; }

        }

    }
}
