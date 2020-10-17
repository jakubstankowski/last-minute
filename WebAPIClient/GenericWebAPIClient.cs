using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Core.Entities;
using Core.Interface;
using Newtonsoft.Json;
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
            _offersRepo = offersRepo;
        }


        public async void CollectTuiDataAsync()
        {
            string postBody = "{\"childrenBirthdays\":[],\"durationFrom\":6,\"durationTo\":14,\"filters\":[{\"filterId\":\"additionalType\",\"selectedValues\":[\"GT03#TUZ-LAST25\"]}],\"metaData\":{\"page\":0,\"pageSize\":30,\"sorting\":\"flightDate\"},\"numberOfAdults\":2,\"offerType\":\"BY_PLANE\",\"site\":\"last-minute?pm_source=MENU&pm_name=Last_Minute\"}";
            var result = await client.PostAsync("https://www.tui.pl/search/offers", new StringContent(postBody, Encoding.UTF8, "application/json"));
            string resultStringContent = await result.Content.ReadAsStringAsync();

            var myDeserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleTuiResponse>(resultStringContent);

            foreach (var offer in myDeserializedClass.Offers)
            {
                /* Console.WriteLine("************* HOTEL NAME: " + offer.hotelName);
                 Console.WriteLine("offer url: " + "https://www.tui.pl" + offer.offerUrl);
                 Console.WriteLine("price: " + offer.originalPerPersonPrice);
                 Console.WriteLine("start date: " + offer.departureDate);
                 Console.WriteLine("back date: " + offer.returnDate);

                 foreach (var breadcrumb in offer.breadcrumbs)
                 {
                     Console.WriteLine("COUNTRY: " + breadcrumb.label);
                 }

                 Console.WriteLine("############## image url: " + offer.imageUrl);*/


                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "itaka.pl",
                    Country = "null",
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
