using System;
using System.Linq;
using TelerikSocial.Models;

namespace TelerikSocial.Services.Implementation
{
	public class UserService : IUserService
	{
		private readonly User currentUser = new User { Name = "Ivan Petrov" };

		public User CurrentUser
		{
			get
			{
				return this.currentUser;
			}
		}
	}
}