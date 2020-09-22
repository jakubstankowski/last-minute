using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IHolidayOffersRepo
    {

        Task<HolidayOffers> GetHolidayOffersByIdAsync(int id);
        Task<IEnumerable<HolidayOffers>> GetHolidayOffersAsync();

        IEnumerable<HolidayOffers> GetHolidayOffersByWebsiteAsync(string website);

        void CreateHolidayOffers(HolidayOffers offers);

        void DeleteHolidayOffersByWebstie(string website);

        bool SaveChanges();
    }
}
