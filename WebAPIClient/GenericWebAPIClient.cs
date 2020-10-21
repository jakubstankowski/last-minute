﻿using System;
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
using static Core.Entities.Wakacje;

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

        public async Task CollectRainbowDataAsync()
        {
            _offersRepo.DeleteHolidayOffersByWebstie("r.pl");


            var getResult = client.GetStringAsync("http://localhost:8080/api/r");
            string stringResult = await getResult;

            var deserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleRainbowResponse>(stringResult);


            foreach (var offer in deserializedClass.Bloczki)
            {
                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "r.pl",
                    Country = offer.BazoweInformacje.Lokalizacje,
                    Title = offer.BazoweInformacje.OfertaNazwa,
                    Price = offer.Ceny[0].CenaZaOsobeAktualna,
                    Url = $"https://www.r.pl{offer.BazoweInformacje.OfertaURL}",
                    Date = $"{offer.TerminWyjazdu}",
                    ImageUrl = offer.Zdjecia[0]
                };


                _offersRepo.CreateHolidayOffers(holidayOffer);

            }

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


        public async Task CollectWakacjeDataAsync()
        {
            _offersRepo.DeleteHolidayOffersByWebstie("wakacje.pl");

            var getResult = client.GetStringAsync("http://localhost:8080/api/wakacje");
            string stringResult = await getResult;

            var deserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleWakacjeResponse>(stringResult);

            foreach (var offer in deserializedClass.data.offers)
            {
                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "wakacje.pl",
                    Country = offer.placeName,
                    Title = offer.name,
                    Price = offer.price,
                    Url = $"https://wakacje.pl{offer.link}",
                    Date = $"{offer.departureDate} - {offer.returnDate}",
                    ImageUrl = $"https://wakacje.pl{offer.photo}"
                };


                _offersRepo.CreateHolidayOffers(holidayOffer);
            }

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
