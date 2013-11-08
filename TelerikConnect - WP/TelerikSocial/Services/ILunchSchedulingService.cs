using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikSocial.Models;

namespace TelerikSocial.Services
{
	public interface ILunchSchedulingService
	{
		Task VoteOption(VotingOption option);

		Task<IEnumerable<VotingOption>> GetVenuesForTeam(string team);

		Task<IEnumerable<VotingOption>> GetTimeSlotsForTeam(string team);
	}
}