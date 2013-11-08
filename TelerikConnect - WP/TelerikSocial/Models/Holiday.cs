using System;
using System.Linq;

namespace TelerikSocial.Models
{
	public class Holiday
	{
		public DateTime Date { get; set; }
		
		public string Description { get; set; }

		public DateTime? WorkOffDate { get; set; }
	}
}