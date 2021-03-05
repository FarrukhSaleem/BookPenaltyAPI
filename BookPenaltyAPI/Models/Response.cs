using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPenaltyAPI.Models
{
	public class Response
	{
		public int BusinessDays { get; set; }
		public int PenaltyDays { get; set; }
		public decimal Fine { get; set; }
		public string Currency { get; set; }
		public int penalizedFactor { get; set; }
	}
}