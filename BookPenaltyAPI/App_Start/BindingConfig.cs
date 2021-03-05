using BookPenaltyAPI.BusinessLayer;
using BookPenaltyAPI.BusinessLayer.Implementation;
using BookPenaltyAPI.DataObjectAccess;
using BookPenaltyAPI.DataObjectAccess.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPenaltyAPI.App_Start
{
	public class BindingConfig
	{
        public static IPenaltyCalculator GetPenaltyCalculator()
        {
            return new PenaltyCalculator();
        }

        public static IPenaltyCalculatorDAO GetPenaltyCalculatorDAO()
        {
            return new PenaltyCalculatorDAO();
        }
    }
}