using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Newtonsoft.Json;
using static Core.Entities.Itaka;
using static Core.Entities.Rainbow;
using static Core.Entities.Tui;


namespace WebAPIClient
{
    public class GenericWebAPIClient : IGenericWebAPIClient
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly IHolidayOffersRepo _offersRepo;

        public GenericWebAPIClient(IHolidayOffersRepo offersRepo)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Accept.UserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36 OPR/71.0.3770.271");
            _offersRepo = offersRepo;
        }

        public async Task CollectItakaDataAsync()
        {
            _offersRepo.DeleteHolidayOffersByWebstie("itaka.pl");

            var getResult = client.GetStringAsync("https://www.itaka.pl/sipl/data/last-minute/search?view=offerList&language=pl&package-type=wczasy&promo=lastMinute&order=priceAsc&total-price=0&page=1&transport=flight&currency=PLN");
            string stringResult = await getResult;

            var deserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleItakaResponse>(stringResult);


            foreach (var offer in deserializedClass.Data)
            {

                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "itaka.pl",
                    Country = offer.canonicalDestinationTitle.ToString(),
                    Title = offer.title,
                    Price = offer.price / 100,
                    Url = $"https://www.itaka.pl{offer.url}",
                    Date = $"{offer.dateFrom} - {offer.dateTo}",
                    ImageUrl = offer.photos.tiny
                };


                _offersRepo.CreateHolidayOffers(holidayOffer);
            }
        }

        public async Task CollectRainbowDataAsync()
        {
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Origin", "https://r.pl");
            client.DefaultRequestHeaders.Add("Referer", "https://r.pl/szukaj?promocja=last-minute^&typyTransportu=air^&typyTransportu=bus^&wiek=1990-09-23^&wiek=1990-09-23^&liczbaPokoi=1^&sortuj=DataAsc^&grupujTerminy=1^&czyCenaZaWszystkich=0^&czyPotwierdzoneTerminy=0^&pokazywaneLotniska=SAME");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36 OPR/71.0.3770.271");
            client.DefaultRequestHeaders.Add("Authority", "rpl-api.r.pl");


            string postBody = "{\"Konfiguracja\":{\"LiczbaPokoi\":\"1\",\"Wiek\":[\"1990 - 09 - 23\",\"1990 - 09 - 23\"]},\"Sortowanie\":{\"CzyPoDacie\":true,\"CzyPoCenie\":false,\"CzyPoOcenach\":false,\"CzyPoPolecanych\":false,\"CzyDesc\":false},\"CzyCenaZaWszystkich\":false,\"CzyGrupowac\":true,\"Promocje\":[\"last - minute\"],\"TypyTransportu\":[\"air\",\"bus\"],\"CzyPotwierdzoneTerminy\":false,\"PokazywaneLotniska\":\"SAME\",\"Paginacja\":{\"Przeczytane\":\"0\",\"IloscDoPobrania\":\"18\"},\"CzyImprezaWeekendowa\":false}";


            var postResult = await client.PostAsync("https://rpl-api.r.pl/v3/wyszukiwarka/api/wyszukaj", new StringContent(postBody, Encoding.UTF8, "application/json"));
            string stringResult = await postResult.Content.ReadAsStringAsync();

            var deserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleRainbowResponse>(stringResult);


            foreach (var offer in deserializedClass.Bloczki)
            {
                Console.WriteLine("COUNTRY: " + offer.CzyCenaZaWszystkich);


            }

        }

        public async Task CollectWakacjeDataAsync()
        {

            client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
            client.DefaultRequestHeaders.Add("Origin", "https://www.wakacje.pl");
            client.DefaultRequestHeaders.Add("Referer", "https://www.wakacje.pl/lastminute/egipt,hiszpania,turcja,malta,portugalia,tunezja/?samolotem");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36 OPR/71.0.3770.271");

            string postBody = "[{\"method\":\"search.tripsSearch\",\"params\":{\"brand\":\"WAK\",\"limit\":10,\"priceHistory\":1,\"imageSizes\":[\"570,428\"],\"flatArray\":true,\"multiSearch\":true,\"withHotelRate\":1,\"withPromoOffer\":1,\"recommendationVersion\":\"noTUI\",\"type\":\"tours\",\"firstMinuteTui\":false,\"countryId\":[\"37\",\"33\",\"99\",\"74\",\"65\",\"16\"],\"regionId\":[],\"cityId\":[],\"hotelId\":[],\"roundTripId\":[],\"cruiseId\":[],\"searchType\":\"lastminute\",\"offersAttributes\":[],\"alternative\":{\"countryId\":[],\"regionId\":[],\"cityId\":[]},\"query\":{\"campTypes\":[],\"qsVersion\":0,\"qsVersionLast\":0,\"tab\":false,\"candy\":false,\"pok\":null,\"flush\":false,\"tourOpAndCode\":null,\"obj_code\":null,\"obj_type\":null,\"catalog\":null,\"roomType\":null,\"test\":null,\"year\":null,\"month\":null,\"rangeDate\":null,\"withoutLast\":0,\"category\":false,\"not - attribute\":false,\"pageNumber\":1,\"departureDate\":\"2020 - 10 - 14\",\"arrivalDate\":\"2022 - 05 - 01\",\"departure\":null,\"type\":[1],\"duration\":{\"min\":7,\"max\":28},\"minPrice\":null,\"maxPrice\":null,\"service\":[],\"firstminute\":null,\"attribute\":[],\"promotion\":[],\"tourId\":null,\"search\":null,\"minCategory\":null,\"maxCategory\":50,\"sort\":13,\"order\":1,\"rank\":null,\"withoutTours\":[],\"withoutCountry\":[],\"withoutTrips\":[],\"rooms\":[{\"adult\":2,\"kid\":0,\"ages\":[],\"inf\":null}],\"offerCode\":null}}}]";

            var postResult = await client.PostAsync("https://www.wakacje.pl/v2/api/offers", new StringContent(postBody, Encoding.UTF8, "application/json"));
            string stringResult = await postResult.Content.ReadAsStringAsync();
            Console.WriteLine(stringResult);

        }

        public async Task CollectTuiDataAsync()
        {
            _offersRepo.DeleteHolidayOffersByWebstie("tui.pl");

            string postBody = "{\"childrenBirthdays\":[],\"durationFrom\":6,\"durationTo\":14,\"filters\":[{\"filterId\":\"additionalType\",\"selectedValues\":[\"GT03#TUZ-LAST25\"]}],\"metaData\":{\"page\":0,\"pageSize\":30,\"sorting\":\"flightDate\"},\"numberOfAdults\":2,\"offerType\":\"BY_PLANE\",\"site\":\"last-minute?pm_source=MENU&pm_name=Last_Minute\"}";

            var postResult = await client.PostAsync("https://www.tui.pl/search/offers", new StringContent(postBody, Encoding.UTF8, "application/json"));
            string stringResult = await postResult.Content.ReadAsStringAsync();

            var deserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleTuiResponse>(stringResult);

            foreach (var offer in deserializedClass.Offers)
            {
                List<string> countryDetails = new List<string>();

                foreach (var country in offer.breadcrumbs)
                {
                    countryDetails.Add(country.label);
                }


                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "tui.pl",
                    Country = countryDetails[0],
                    Title = offer.hotelName,
                    Price = Int32.Parse(offer.originalPerPersonPrice),
                    Url = $"https://www.tui.pl{offer.offerUrl}",
                    Date = $"{offer.departureDate} - {offer.returnDate}",
                    ImageUrl = offer.imageUrl
                };


                _offersRepo.CreateHolidayOffers(holidayOffer);

            }

        }





    }
}
