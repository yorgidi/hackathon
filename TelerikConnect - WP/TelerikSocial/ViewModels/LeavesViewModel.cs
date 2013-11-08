using System;
using System.Collections.ObjectModel;
using System.Linq;
using TelerikSocial.Models;

namespace TelerikSocial.ViewModels
{
	public class LeavesViewModel : CustomViewModelBase
	{
		public int PaidDays { get; set; }

		public int BonusDays { get; set; }

		public ObservableCollection<Holiday> Holidays { get; set; }

		public LeavesViewModel()
		{
			this.PaidDays = 7;
			this.BonusDays = 1;

			this.Holidays = new ObservableCollection<Holiday>(new[]
			{
				new Holiday { Date = new DateTime(2013, 12, 24), Description = "Christmas" },
				new Holiday { Date = new DateTime(2013, 12, 25), Description = "Christmas" },
				new Holiday { Date = new DateTime(2013, 12, 26), Description = "Christmas" },
				new Holiday { Date = new DateTime(2013, 12, 31), Description = "New Year", WorkOffDate = new DateTime(2013, 12, 14) },
				new Holiday { Date = new DateTime(2014, 1, 1), Description = "New Year" },
				new Holiday { Date = new DateTime(2014, 3, 3), Description = "Liberation Day" },
				new Holiday { Date = new DateTime(2014, 4, 18), Description = "Easter" },
				new Holiday { Date = new DateTime(2014, 4, 19), Description = "Easter" },
				new Holiday { Date = new DateTime(2014, 4, 20), Description = "Easter" },
				new Holiday { Date = new DateTime(2014, 5, 1), Description = "Labor Day", WorkOffDate = new DateTime(2014, 5, 17) },
				new Holiday { Date = new DateTime(2014, 5, 6), Description = "St. George's Day" },
				new Holiday { Date = new DateTime(2014, 5, 24), Description = "Literacy Day" },
				new Holiday { Date = new DateTime(2014, 9, 6), Description = "Union Day" },
				new Holiday { Date = new DateTime(2014, 9, 22), Description = "Independence Day" },
			});
		}
	}
}