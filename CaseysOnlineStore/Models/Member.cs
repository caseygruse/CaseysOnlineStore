using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseysOnlineStore.Models
{
	public class Member
	{
		[Key]
		public int MemberID { get; set; }

		//make sure not duplicate usernames are used.
		[Required]
		public string UserName { get; set; }
		[Required]
		[EmailAddress]
		public string EmailAddress { get; set; }
		[Required]
		public string Password { get; set; }

		public string MobilePhone { get; set; }

		public string FullName { get; set; }

		public string CreditCard { get; set; }

		public string Address { get; set; }

	}

	/// <summary>
	/// view model for the registration page.
	/// </summary>
	public class RegistrationViewModel
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[Compare(nameof(Password))]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

	}
}