using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Newtonsoft.Json;
using static Core.Entities.Itaka;
using static Core.Entities.Rainbow;
using static Core.Entities.Tui;
using static Core.Entities.Wakacje;

namespace Infrastructure.Services
{
    public class HolidayOffersService : IHolidayOffersService
    {
        private readonly IHolidayOffersRepo _offersRepo;
        private static readonly HttpClient client = new HttpClient();

        public HolidayOffersService(IHolidayOffersRepo offersRepo)
        {
            _offersRepo = offersRepo;
        }

        public IEnumerable<HolidayOffers> GetHolidayOffersByUserHolidayPreference(IEnumerable<HolidayOffers> holidayOffers, HolidayPreferences holidayPreference, string sort)
        {
            List<string> preferenceWebsitesList = new List<string>();

            foreach (var holidayPreferencesWebsite in holidayPreference.Websites)
            {
                preferenceWebsitesList.Add(holidayPreferencesWebsite.Website);
            }


            var filteredOffers = holidayOffers
                                              .Where((o) => preferenceWebsitesList.Contains(o.Website))
                                              .Where((o) => o.Price <= holidayPreference.MaxPrice)
                                              .ToList();

            switch (sort)
            {
                case "priceAsc":
                    return filteredOffers.OrderBy(s => s.Price);
                case "priceDesc":
                    return filteredOffers.OrderByDescending(o => o.Price);
                default:
                    return filteredOffers;
            }

        }

        public async Task RefreshItakaOffersAsync()
        {
            ResetHolidayOffers("itaka.pl");

            var getResult = client.GetStringAsync("https://www.itaka.pl/sipl/data/last-minute/search?view=offerList&language=pl&package-type=wczasy&promo=lastMinute&order=priceAsc&total-price=0&page=1&transport=flight&currency=PLN");
            string stringResult = await getResult;

            var deserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleItakaResponse>(stringResult);


            foreach (var offer in deserializedClass.Data)
            {

                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "itaka.pl",
                    Country = StripHTML(offer.canonicalDestinationTitle.ToString()),
                    Meal = offer.meal,
                    Title = offer.title,
                    Price = offer.price / 100,
                    Duration = offer.duration,
                    Url = $"https://www.itaka.pl{offer.url}",
                    Date = $"{offer.dateFrom} - {offer.dateTo}",
                    ImageUrl = offer.photos.tiny
                };


                _offersRepo.CreateHolidayOffers(holidayOffer);
            }
        }

        public async Task RefreshRainbowOffersAsync()
        {
            ResetHolidayOffers("r.pl");

            var getResult = client.GetStringAsync("https://last-minute-js-api.herokuapp.com/api/offers/refresh/r");
            string stringResult = await getResult;

            var deserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleRainbowResponse>(stringResult);


            foreach (var offer in deserializedClass.Bloczki)
            {
                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "r.pl",
                    Country = offer.BazoweInformacje.Lokalizacje == null ? "null" : offer.BazoweInformacje.Lokalizacje,
                    Meal = offer.Wyzywienia == null ? "brak" : offer.Wyzywienia[0].Nazwa,
                    Title = offer.BazoweInformacje.OfertaNazwa == null ? "null" : offer.BazoweInformacje.OfertaNazwa,
                    Price = offer.Ceny == null ? 0 : offer.Ceny[0].CenaZaOsobeAktualna,
                    Url = offer.BazoweInformacje.OfertaURL == null ? "null" : $"https://www.r.pl{offer.BazoweInformacje.OfertaURL}",
                    Date = offer.TerminWyjazdu == null ? "null" : offer.TerminWyjazdu.ToString(),
                    Duration = offer.Ceny?[0].LiczbaDni,
                    ImageUrl = offer.Zdjecia == null || offer.Zdjecia.Count == 0 ? "null" : offer.Zdjecia[0]
                };
               

                _offersRepo.CreateHolidayOffers(holidayOffer);

            }
        }


        public async Task RefreshTuiOffersAsync()
        {
            ResetHolidayOffers("tui.pl");

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
                    Meal = offer.boardType,
                    Title = offer.hotelName,
                    Price = Int32.Parse(offer.originalPerPersonPrice),
                    Duration = offer.duration,
                    Url = $"https://www.tui.pl{offer.offerUrl}",
                    Date = $"{offer.departureDate} - {offer.returnDate}",
                    ImageUrl = offer.imageUrl
                };


                _offersRepo.CreateHolidayOffers(holidayOffer);

            }

        }

        public async Task RefreshWakacjeOffersAsync()
        {
            ResetHolidayOffers("wakacje.pl");
            var getResult = client.GetStringAsync("https://last-minute-js-api.herokuapp.com/api/offers/refresh/wakacje");
            string stringResult = await getResult;

            var deserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleWakacjeResponse>(stringResult);

            foreach (var offer in deserializedClass.data.offers)
            {
                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "wakacje.pl",
                    Country = offer.placeName,
                    Meal = offer.serviceDesc,
                    Title = offer.name,
                    Price = offer.price,
                    Duration = offer.duration,
                    Url = $"https://wakacje.pl{offer.link}",
                    Date = $"{offer.departureDate} - {offer.returnDate}",
                    ImageUrl = $"https://wakacje.pl{offer.photo}"
                };


                _offersRepo.CreateHolidayOffers(holidayOffer);
            }
        }

        public void ResetHolidayOffers(string website)
        {
            _offersRepo.DeleteHolidayOffersByWebstie(website);
        }

        public async Task RefreshAllOffers()
        {
            await RefreshItakaOffersAsync();
            await RefreshRainbowOffersAsync();
            await RefreshTuiOffersAsync();
            await RefreshWakacjeOffersAsync();
        }

        public string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
