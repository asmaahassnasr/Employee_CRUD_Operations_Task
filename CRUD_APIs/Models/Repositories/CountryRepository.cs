using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APIs.Models.Repositories
{
    public class CountryRepository : ICountryRepository 
    {
        private readonly AppDbContext appDbContext;

        public CountryRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await (appDbContext.Countries.ToListAsync());
        }

        public async Task<Country> GetCountryById(int id)
        {

            return await appDbContext.Countries.FirstOrDefaultAsync(c => c.CountryId == id);
        }


        public async Task<Country> AddCountry(Country country)
        {
           
            var result = await appDbContext.Countries.AddAsync(country);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
