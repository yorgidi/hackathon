using System;
using System.Linq;
using TelerikSocial.Models;

namespace TelerikSocial.Services
{
	public interface IUserService
	{
		User CurrentUser { get; }
	}
}