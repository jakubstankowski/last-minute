using System.Collections.Generic;

namespace Core.Entities
{
    public class Tui
    {
        public class RetrieveMultipleTuiResponse
        {
            public List<Offer> Offers { get; set; }
        }


        public class Offer
        {
            public string hotelName { get; set; }
            public string offerUrl { get; set; }
            public List<Breadcrumb> breadcrumbs { get; set; }

            public string originalPerPersonPrice { get; set; }
            public string departureDate { get; set; }
            public string returnDate { get; set; }
            public string departureTime { get; set; }
            public string departureAirport { get; set; }

            public string imageUrl { get; set; }
            public string boardType { get; set; }
        }

        public class Breadcrumb
        {
            public string label { get; set; }
            public string url { get; set; }
        }
    }
}
