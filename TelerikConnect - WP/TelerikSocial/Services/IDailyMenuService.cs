using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikSocial.Models;

namespace TelerikSocial.Services
{
	public interface IDailyMenuService
	{
		Task<IEnumerable<Group<MenuItem>>> GetDailyMenu();
	}
}