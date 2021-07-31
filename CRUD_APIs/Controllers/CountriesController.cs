using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_APIs.Models.Repositories;
using CRUD_APIs.Models;

namespace CRUD_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        public CountriesController(ICountryRepository _countryRepository)
        {
            countryRepository = _countryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCountries()
        {
            try
            {
                // Ok : status code => 200 
                return Ok(await countryRepository.GetCountries());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the server");
            }
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            try
            {
                var result = await countryRepository.GetCountryById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the server");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry(Country country)
        {
            try
            {
                if (country == null)
                    return BadRequest();

                var newCountry = await countryRepository.AddCountry(country);
                return CreatedAtAction(nameof(GetCountryById), new { id = newCountry.CountryId }, newCountry);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorr Creating new Employee record");

            }
        }

    }
}
