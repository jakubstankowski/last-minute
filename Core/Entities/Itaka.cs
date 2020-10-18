using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    class Itaka
    {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class OfferId
        {
            public string itaka { get; set; }
        }

        public class MealDetails
        {
            public string id { get; set; }
            public string title { get; set; }
        }

        public class Photos
        {
            public string main { get; set; }
            public string panorama { get; set; }
            public string tiny { get; set; }
            public List<string> gallery { get; set; }
            public List<object> mobileGallery { get; set; }
        }

        public class Ratings
        {
            public int hotel { get; set; }
            public int overall { get; set; }
        }

        public class CategoryType
        {
            public string id { get; set; }
            public string title { get; set; }
        }

        public class From
        {
            public string code { get; set; }
            public string city { get; set; }
            public string airportName { get; set; }
            public string date { get; set; }
            public string time { get; set; }
        }

        public class To
        {
            public string code { get; set; }
            public string city { get; set; }
            public string airportName { get; set; }
            public string date { get; set; }
            public string time { get; set; }
        }

        public class Departure
        {
            public string id { get; set; }
            public From from { get; set; }
            public To to { get; set; }
        }

        public class From2
        {
            public string code { get; set; }
            public string city { get; set; }
            public string airportName { get; set; }
            public string date { get; set; }
            public string time { get; set; }
        }

        public class To2
        {
            public string code { get; set; }
            public string city { get; set; }
            public string airportName { get; set; }
            public string date { get; set; }
            public string time { get; set; }
        }

        public class Return
        {
            public string id { get; set; }
            public From2 from { get; set; }
            public To2 to { get; set; }
        }

        public class AdditionalHotel
        {
        }

        public class ReviewsRatings
        {
            public double foodService { get; set; }
            public double highlights { get; set; }
            public double qualityByPrice { get; set; }
            public double animations { get; set; }
            public double beach { get; set; }
            public double hotel { get; set; }
            public double staff { get; set; }
            public double location { get; set; }
            public double room { get; set; }
            public int comfort { get; set; }
        }

        public class Offer
        {
            public string packageCode { get; set; }
            public string uid { get; set; }
            public string packageType { get; set; }
            public OfferId offerId { get; set; }
            public int price { get; set; }
            public string currency { get; set; }
            public string dateFrom { get; set; }
            public string dateTo { get; set; }
            public int duration { get; set; }
            public int oldPrice { get; set; }
            public string meal { get; set; }
            public MealDetails mealDetails { get; set; }
            public List<string> promotion { get; set; }
            public object canonicalDestinationTitle { get; set; }
            public Photos photos { get; set; }
            public List<string> assets { get; set; }
            public string title { get; set; }
            public Ratings ratings { get; set; }
            public List<CategoryType> categoryTypes { get; set; }
            public List<object> tripDifficultyLevels { get; set; }
            public string url { get; set; }
            public int reviewsCount { get; set; }
            public bool isConfirmed { get; set; }
            public bool ownTransport { get; set; }
            public string departureRegion { get; set; }
            public string transport { get; set; }
            public string offerStatus { get; set; }
            public Departure departure { get; set; }
            public Return @return { get; set; }
            public int beachDistance { get; set; }
            public int positiveReviewsPercentage { get; set; }
            public string tourCode { get; set; }
            public object address { get; set; }
            public AdditionalHotel additionalHotel { get; set; }
            public List<object> bookingRequirements { get; set; }
            public bool isPromoted { get; set; }
            public bool isBestseller { get; set; }
            public ReviewsRatings reviewsRatings { get; set; }
            public int pricePerGroup { get; set; }
            public bool totalPrice { get; set; }
        }

        public class Root
        {
            public List<Offer> offers { get; set; }
        }


    }
}
