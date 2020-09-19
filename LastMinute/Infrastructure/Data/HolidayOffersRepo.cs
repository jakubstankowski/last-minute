
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class HolidayOffersRepo : IHolidayOffersRepo
    {
        private DataContext _context;
       

        public HolidayOffersRepo(DataContext context)
        {
            _context = context;
        }


        public async Task<HolidayOffers> GetHolidayOffersByIdAsync(int id)
        {
            return await _context.HolidayOffers.FindAsync(id);
        }

        public async Task<IEnumerable<HolidayOffers>> GetHolidayOffersAsync()
        {

            return await _context.HolidayOffers.ToListAsync();
        }

        public IEnumerable<HolidayOffers> GetHolidayOffersByWebsiteAsync(string website)
        {
             return  _context.HolidayOffers.Where(o => o.Website == website).ToList();
        }

        public void CreateHolidayOffers(HolidayOffers offers)
        {
            _context.HolidayOffers.Add(offers);
            _context.SaveChanges();
        }

        public void DeleteHolidayOffersByWebstie(string website)
        {
            IEnumerable<HolidayOffers> offersToRemove = GetHolidayOffersByWebsiteAsync(website);
            _context.RemoveRange(offersToRemove);
            _context.SaveChanges();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}



