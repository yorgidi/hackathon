using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using TelerikSocial.Models;

namespace TelerikSocial.Services.Implementation
{
	public class LunchSchedulingService : ILunchSchedulingService
	{
		private readonly IUserService userService = SimpleIoc.Default.GetInstance<IUserService>();

		public async Task VoteOption(VotingOption option)
		{
			if (option == null)
			{
				return;
			}

			var username = this.userService.CurrentUser.Name;
			if (option.PeopleJoined.Contains(username))
			{
				option.PeopleJoined.Remove(username);
			}
			else
			{
				option.PeopleJoined.Add(username);
			}
		}

		public async Task<IEnumerable<VotingOption>> GetVenuesForTeam(string team)
		{
			return new[]
			{
				new VotingOption("Cafeteria"),
				new VotingOption("Dino"),
				new VotingOption("Happy"),
				new VotingOption("Biju"),
				new VotingOption("Кипарисите"),
				new VotingOption("Мръсно"),
				new VotingOption("Пици-Фрици"),
			};
		}

		public async Task<IEnumerable<VotingOption>> GetTimeSlotsForTeam(string team)
		{
			return new[]
			{
				new VotingOption("12:00"),
				new VotingOption("12:30"),
				new VotingOption("13:00"),
			};
		}
	}
}