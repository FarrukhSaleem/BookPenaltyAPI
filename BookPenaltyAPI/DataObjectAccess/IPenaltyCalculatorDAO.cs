using BookPenaltyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPenaltyAPI.DataObjectAccess
{
    public interface IPenaltyCalculatorDAO
    {
        IEnumerable<Country> GetAllCountries();

        Country GetCountry(int countryId);

        IEnumerable<CountryBusinessDaysConfig> GetPaneltyByCountry(int countryId);
    }
}