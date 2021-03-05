using BookPenaltyAPI.App_Start;
using BookPenaltyAPI.BusinessLayer;
using BookPenaltyAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BookPenaltyAPI.Controllers
{
    public class CountryController : ApiController
    {
        // GET: api/Country
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Country/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Country
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Country/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Country/5
        public void Delete(int id)
        {
        }

        private readonly IPenaltyCalculator PenaltyCalculator;
        public CountryController()
        {
            this.PenaltyCalculator = BindingConfig.GetPenaltyCalculator();
        }
        [HttpGet]
        [Route("api/Country/GetAllCountries")]
        public IEnumerable<Country> GetAllCountries()
        {
            return PenaltyCalculator.GetAllCountries();
        }

        [HttpGet]
        [Route("api/Country/GetPaneltyByCountry")]
        public Response GetPaneltyByCountry(int countryId, DateTime checkoutDate, DateTime returnDate)
        {
            return PenaltyCalculator.GetPaneltyByCountry(countryId, checkoutDate, returnDate);
        }
    }
}
