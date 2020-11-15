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

        public IEnumerable<HolidayOffers> GetHolidayOffersByUserHolidayPreference(IEnumerable<HolidayOffers> holidayOffers, HolidayPreferences holidayPreference, string order)
        {
            // TODO LM-61 bug with return wrong holiday offers!
            List<HolidayOffers> offers = new List<HolidayOffers>();

            foreach (var website in holidayPreference.Websites)
            {
                foreach (var offer in holidayOffers)
                {
                    if (offer.Website == website.Website && offer.Price >= holidayPreference.MinPrice && offer.Price <= holidayPreference.MaxPrice)
                    {
                        offers.Add(offer);
                    }
                }
            }


            switch (order)
            {
                case "priceAsc":
                    return offers.OrderBy(s => s.Price);
                case "priceDesc":
                    return offers.OrderByDescending(o => o.Price);
                default:
                    return offers;
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

            var getResult = client.GetStringAsync("http://localhost:3000/api/offers/refresh/r");
            string stringResult = await getResult;

            var deserializedClass = JsonConvert.DeserializeObject<RetrieveMultipleRainbowResponse>(stringResult);


            foreach (var offer in deserializedClass.Bloczki)
            {
                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "r.pl",
                    Country = offer.BazoweInformacje.Lokalizacje,
                    Meal = offer.Wyzywienia[0].Nazwa,
                    Title = offer.BazoweInformacje.OfertaNazwa,
                    Price = offer.Ceny[0].CenaZaOsobeAktualna,
                    Url = $"https://www.r.pl{offer.BazoweInformacje.OfertaURL}",
                    Date = $"{offer.TerminWyjazdu}",
                    ImageUrl = offer.Zdjecia == null ? "https://lh3.googleusercontent.com/proxy/BPq1gEyIcFJ72uMKbDvFqlpJRiW2_mttgxsU0G2RlQ0al4b1GUHiTqNZ_sjkoeTsf9A-OtFPAmVrcCBi3Jz1Cr1kLJEp9AkO1dIhu9ZOvjWfJJS1LBCcOrmRIPYGRXyvCnRRr0KalXBiiPGf8aGrvlBsIpHw2vmMZ-Is9wM2EvQAenYZ5Saa5JoWU50bQuiuyinmaw" : offer.Zdjecia[0]
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
            var getResult = client.GetStringAsync("http://localhost:3000/api/offers/refresh/wakacje");
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
