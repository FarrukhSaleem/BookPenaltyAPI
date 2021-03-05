using BookPenaltyAPI.App_Start;
using BookPenaltyAPI.DataObjectAccess;
using BookPenaltyAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BookPenaltyAPI.BusinessLayer.Implementation
{
    public class PenaltyCalculator : IPenaltyCalculator
    {
        private readonly IPenaltyCalculatorDAO PenaltyCalculatorDAO;

        public PenaltyCalculator()
        {
            this.PenaltyCalculatorDAO = BindingConfig.GetPenaltyCalculatorDAO();
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return this.PenaltyCalculatorDAO.GetAllCountries();
        }

        public Country GetCountry(int countryId)
        {
            return this.PenaltyCalculatorDAO.GetCountry(countryId);
        }

        public Response GetPaneltyByCountry(int countryId, DateTime checkoutDate, DateTime returnDate)
        {
            int AllowedBusinessDays = Convert.ToInt32(ConfigurationManager.AppSettings["AllowedBusinessDays"].ToString());
            int penalizedFactor = Convert.ToInt32(ConfigurationManager.AppSettings["penalizedFactor"].ToString());


            Country country = GetCountry(countryId);
            List<CountryBusinessDaysConfig> holidays = PenaltyCalculatorDAO.GetPaneltyByCountry(countryId).ToList();
            List<DateTime> dateRange = CreateDateRangeWithoutHoliday(checkoutDate, returnDate, holidays);
            decimal penaltyAmount = (dateRange.Count() - AllowedBusinessDays) > 0 ? (dateRange.Count() - AllowedBusinessDays) * penalizedFactor : 0;
            string penaltyAmountCurrency = string.Format("{0:#,##0.##}", penaltyAmount);

            Response r = new Response();
            r.BusinessDays = dateRange.Count();
            r.PenaltyDays = (dateRange.Count() - AllowedBusinessDays) > 0 ? (dateRange.Count() - AllowedBusinessDays) : 0;
            r.Fine = penaltyAmount;
            r.Currency = country.CountryCode;
            r.penalizedFactor = penalizedFactor;
            return r;
        }


        #region Penalty Calculation
        public List<DateTime> CreateDateRangeWithoutHoliday(DateTime from, DateTime to, List<CountryBusinessDaysConfig> holidays)
        {

            List<DateTime> dateRange = new List<DateTime>();
            while (from <= to)
            {
                var weekDay = holidays.Where(x => x.HolidayType.Equals(HolidayType.WeekEnd) && x.WeekDay.Equals(from.DayOfWeek));
                var nationalDay = holidays.Where(x => x.HolidayType.Equals(HolidayType.NationalDay) && x.Day.Equals(from.Day) && x.Month.Equals(from.Month));

                if (!(weekDay.Count() > 0 || nationalDay.Count() > 0))
                {
                    dateRange.Add(from);
                }
                from = from.AddDays(1);
            }
            return dateRange;
        }


        #endregion
    }
}