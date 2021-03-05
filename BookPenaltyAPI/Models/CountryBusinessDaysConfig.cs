using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookPenaltyAPI.Models
{
	public enum HolidayType
	{
		WeekEnd = 0,
		NationalDay = 1
	}
	public class CountryBusinessDaysConfig
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        [Required]
        public HolidayType HolidayType { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        public int Month { get; set; }
        public DayOfWeek WeekDay { get; set; }


        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}