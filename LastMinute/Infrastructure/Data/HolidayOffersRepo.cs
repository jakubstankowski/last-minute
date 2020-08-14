using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;


namespace Infrastructure.Data
{
    public class HolidayOffersRepo : IHolidayOffersRepo
    {
        private readonly DataContext _context;

        public HolidayOffersRepo(DataContext context)
        {
            _context = context;
        }

        public void CreateHolidayOffers(HolidayOffers offers)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<HolidayOffers>> GetHolidayOffersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HolidayOffers> GetHolidayOffersByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
