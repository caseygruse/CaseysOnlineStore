using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseysOnlineStore.Controllers
{
	public static class SessionHelper
	{
		private const string Username = "Username";
		private const string Role = "Role";
		private const string DefaultRole = "Customer";
		private const string Administrator = "Admin";

		/// <summary>
		/// Returns the username of the currently logged
		/// in user, or null
		/// </summary>
		/// <returns></returns>
		public static string GetUsername()
		{
			if (IsUserLoggedIn())
			{
				return HttpContext.Current
					.Session[Username]
					.ToString();
			}
			return null;
		}

		public static bool IsCustomer()
		{
			if (HttpContext.Current.Session[Role].ToString()
				== DefaultRole)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Log in already verified user, with default role
		/// </summary>
		/// <param name="username">The user to login</param>
		public static void LogUserIn(string username)
		{
			LogUserIn(username, DefaultRole);
		}

		public static void LogUserIn(string username, string role)
		{
			HttpContext.Current.Session[Username]
				= username;
			HttpContext.Current.Session[Role]
				= role;
		}

		/// <summary>
		/// Kill current user session
		/// </summary>
		public static void LogUserOut()
		{
			HttpContext.Current.Session.Abandon();
		}

		public static bool IsUserLoggedIn()
		{
			if (HttpContext.Current.Session[Username] == null)
				return false;
			return true;
		}

		public static bool IsAdmin()
		{
			string role = HttpContext.Current
							.Session[Role].ToString();
			if (role == Administrator)
				return true;

			return false;
		}
	}
}