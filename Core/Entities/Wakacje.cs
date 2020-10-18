using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Wakacje
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Country
        {
            public int id { get; set; }
            public string name { get; set; }
            public string urlName { get; set; }
            public object locativeName { get; set; }
            public object locativePrefix { get; set; }
            public string type { get; set; }
        }

        public class Region
        {
            public int id { get; set; }
            public string name { get; set; }
            public string urlName { get; set; }
            public object locativeName { get; set; }
            public object locativePrefix { get; set; }
            public string type { get; set; }
        }

        public class City
        {
            public int? id { get; set; }
            public string name { get; set; }
            public string urlName { get; set; }
            public object locativeName { get; set; }
            public object locativePrefix { get; set; }
            public string type { get; set; }
        }

        public class Place
        {
            public Country country { get; set; }
            public Region region { get; set; }
            public City city { get; set; }
        }

        public class Offer
        {
            public string id { get; set; }
            public string name { get; set; }
            public string placeName { get; set; }
            public string link { get; set; }
            public string photo { get; set; }
            public string hotelId { get; set; }
            public int offerId { get; set; }
            public string urlName { get; set; }
            public int category { get; set; }
            public int maxCategory { get; set; }
            public Place place { get; set; }
            public bool promoted { get; set; }
            public int duration { get; set; }
            public int durationNights { get; set; }
            public bool promoFirstMinute { get; set; }
            public bool promoLastMinute { get; set; }
            public bool promoTop10 { get; set; }
            public bool promoTop10Kids { get; set; }
            public bool promoNew { get; set; }
            public List<object> promotionTags { get; set; }
            public bool tagTouristVoucher { get; set; }
            public bool tagUniqueOffer { get; set; }
            public int price { get; set; }
            public int priceDiscount { get; set; }
            public int priceOld { get; set; }
            public string departureDate { get; set; }
            public string returnDate { get; set; }
            public int departureType { get; set; }
            public string departureTypeName { get; set; }
            public List<string> departurePlaces { get; set; }
            public string departurePlace { get; set; }
            public string returnDestinationPlace { get; set; }
            public int service { get; set; }
            public string serviceDesc { get; set; }
            public int tourOperator { get; set; }
            public string tourOperatorName { get; set; }
            public string ratingString { get; set; }
            public double ratingValue { get; set; }
            public string ratingLabel { get; set; }
            public int ratingMax { get; set; }
            public int ratingRecommends { get; set; }
            public int ratingRecommendsPercent { get; set; }
            public object tripsRecommendationPercent { get; set; }
            public int ratingReservationCount { get; set; }
            public object holidayRecommendation { get; set; }
            public object holidayRecommendationPercent { get; set; }
            public object holidayRate { get; set; }
            public object holidayValueRate { get; set; }
            public int holidayMaxRate { get; set; }
            public bool isPackage { get; set; }
            public int originalCurrencyPrice { get; set; }
            public string originalCurrency { get; set; }
            public string shownCurrency { get; set; }
            public string roomType { get; set; }
            public string offerType { get; set; }
            public string offerHash { get; set; }
            public string mxCode { get; set; }
            public string mxType { get; set; }
            public string departureDates { get; set; }
            public string durationOptions { get; set; }
            public string hideInfo { get; set; }
            public bool isAfter2013 { get; set; }
            public bool preSale { get; set; }
            public int qsVersion { get; set; }
            public string wakQualityScore { get; set; }
            public string egQualityScore { get; set; }
            public bool promotionAmount { get; set; }
            public bool exotic { get; set; }
            public bool ski { get; set; }
            public string preName { get; set; }
            public string tourOpCode { get; set; }
            public string objXCode { get; set; }
            public string objCode { get; set; }
            public string objType { get; set; }
        }

        public class Filters
        {
        }

        public class Data
        {
            public List<Offer> offers { get; set; }
            public int count { get; set; }
            public Filters filters { get; set; }
            public string qsSegment { get; set; }
        }

        public class Root
        {
            public bool success { get; set; }
            public string type { get; set; }
            public string msg { get; set; }
            public DateTime datetime { get; set; }
            public Data data { get; set; }
        }


    }
}
