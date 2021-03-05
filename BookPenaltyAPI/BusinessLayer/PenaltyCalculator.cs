using BookPenaltyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPenaltyAPI.BusinessLayer
{
    public interface IPenaltyCalculator
    {
        IEnumerable<Country> GetAllCountries();

        Country GetCountry(int countryId);

        Response GetPaneltyByCountry(int countryId, DateTime checkoutDate, DateTime returnDate);
    }
}