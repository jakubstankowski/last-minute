using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

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
            _context.HolidayOffers.Add(offers);
            _context.SaveChanges();
        }

        public async Task<IReadOnlyList<HolidayOffers>> GetHolidayOffersAsync()
        {
            return await _context.HolidayOffers.ToListAsync();
        }

        public async  Task<HolidayOffers> GetHolidayOffersByIdAsync(int id)
        {
            return await _context.HolidayOffers.FirstOrDefaultAsync();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
