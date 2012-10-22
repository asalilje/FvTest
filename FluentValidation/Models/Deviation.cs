using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FVTest.Models
{
	public class Deviation
	{
		public int Id { get; set; }

		[Display(Name = "Type")]
		public IEnumerable<string> Types { get; set; }

		public int SelectedType { get; set; }

		[Display(Name = "From date")]
		public string PeriodFromDate { get; set; }

		[Display(Name = "To date")]
		public string PeriodToDate { get; set; }

		[Display(Name = "Owner")]
		public string User { get; set; }

		[Display(Name = "Enter something here")]
		public string Enter1 { get; set; }

		[Display(Name = "Or here. Or both.")]
		public string Enter2 { get; set; }

	}


}