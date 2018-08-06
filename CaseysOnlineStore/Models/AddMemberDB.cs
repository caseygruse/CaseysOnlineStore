using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseysOnlineStore.Models
{
	public class AddMemberDB
	{

		public static void AddMemeber(Member m)
		{
			var context = new CommereceDBContext();

			context.Members.Add(m);

			context.SaveChanges();
		}

		public static bool IsUsernameTaken(RegistrationViewModel reg)
		{
			//check if username is unique
			var db = new CommereceDBContext();
			bool isNameTaken = (from mem in db.Members
								where mem.UserName == reg.UserName
								select mem).Count() == 1;
			return isNameTaken;
		}
	}
}