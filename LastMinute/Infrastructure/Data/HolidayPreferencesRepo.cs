﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class HolidayPreferencesRepo : IHolidayPreferencesRepo
    {
        private readonly AppIdentityDbContext _userContext;
        private DataContext _context;


        public HolidayPreferencesRepo(DataContext context, AppIdentityDbContext userContext)
        {
            _userContext = userContext;
            _context = context;
        }

        public async Task<HolidayPreferences> GetHolidayPreferenceByIdAsync(int id)
        {
            return await _context.HolidayPreferences.FindAsync(id);
        }

        public async Task<HolidayPreferences[]> GetHolidayPreferencesAsync(string userId)
        {
          
            IQueryable<HolidayPreferences> query = _context.HolidayPreferences.Where(h => h.AppUserId == userId);

            return await query.ToArrayAsync();

        }

      
        public void CreateHolidayPreference(HolidayPreferences preference)
        {
            _context.HolidayPreferences.Add(preference);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

      
    }
}
