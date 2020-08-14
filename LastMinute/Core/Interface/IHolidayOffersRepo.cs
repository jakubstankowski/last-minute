using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IHolidayOffersRepo
    {

        Task<HolidayOffers> GetHolidayOffersByIdAsync(int id);
        Task<IReadOnlyList<HolidayOffers>> GetHolidayOffersAsync();
        void CreateHolidayOffers(HolidayOffers offers);
        bool SaveChanges();
    }
}
