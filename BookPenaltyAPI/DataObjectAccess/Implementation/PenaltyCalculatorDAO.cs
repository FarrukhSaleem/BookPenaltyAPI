using BookPenaltyAPI.DataAccessLayer;
using BookPenaltyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPenaltyAPI.DataObjectAccess.Implementation
{
    public class PenaltyCalculatorDAO : IPenaltyCalculatorDAO
    {
        public IEnumerable<Country> GetAllCountries()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    return context.Countries.ToList<Country>();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Country GetCountry(int countryId)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    return context.Countries.Where(x => x.ID.Equals(countryId)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<CountryBusinessDaysConfig> GetPaneltyByCountry(int countryId)
        {
            try
            {
                List<CountryBusinessDaysConfig> holidays = new List<CountryBusinessDaysConfig>();
                using (var context = new DatabaseContext())
                {
                    return context.CountryBusinessDaysConfigs.Where(x => x.CountryId.Equals(countryId)).ToList<CountryBusinessDaysConfig>();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}