using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APIs.Models.Repositories
{
  public  interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountryById(int id);
    }
}
