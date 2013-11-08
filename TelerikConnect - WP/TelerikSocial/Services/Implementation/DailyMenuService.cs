using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikSocial.Models;

namespace TelerikSocial.Services.Implementation
{
	public class DailyMenuService : IDailyMenuService
	{
		public async Task<IEnumerable<Group<MenuItem>>> GetDailyMenu()
		{
			return new[]
			{
				new Group<MenuItem>(new[]
				{
					new MenuItem { Name = "tomato basil soup", Price = 3 },
					new MenuItem { Name = "spicy acorn squash soup", Price = 3 },
				}) { Title = "soups", Color = "A075A3FF" },
				new Group<MenuItem>(new[]
				{
					new MenuItem { Name = "caeser", Price = 2.5 },
					new MenuItem { Name = "asian sessame grain", Price = 2.5 },
				}) { Title = "salads", Color = "A08DE28D"},
				new Group<MenuItem>(new[]
				{
					new MenuItem { Name = "pan-fried sea scallops", Price = 4 },
					new MenuItem { Name = "sautéed foie gras", Price = 5 },
					new MenuItem { Name = "poached scottish lobster", Price = 4 },
					new MenuItem { Name = "pressed foie gras", Price = 3.5 },
					new MenuItem { Name = "isle of gigha halibut", Price = 5 },
					new MenuItem { Name = "bresse pigeon", Price = 6 },
				}) { Title = "main dishes", Color = "A0D65C33"},
				new Group<MenuItem>(new[]
				{
					new MenuItem { Name = "smoked chocolate cigar", Price = 1.5 },
					new MenuItem { Name = "coconut soufflé", Price = 2 },
				}) { Title = "desserts", Color = "A0D6C0E6"},
			};
		}
	}
}