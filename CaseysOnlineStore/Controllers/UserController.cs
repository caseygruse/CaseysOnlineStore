using CaseysOnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseysOnlineStore.Controllers
{
    public class UserController : Controller
    {
        // GET: User
		[HttpGet]
        public ActionResult Register()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Register(RegistrationViewModel reg)
		{
			if (ModelState.IsValid)
			{
				if (AddMemberDB.IsUsernameTaken(reg))
				{
					ModelState.AddModelError("UsernameTaken", "Username already Taken");
					return View(reg);
				}

				Member m = new Member()
				{
					UserName = reg.UserName,
					EmailAddress = reg.Email,
					Password = reg.Password,

				};
				AddMemberDB.AddMemeber(m);

				return RedirectToAction("Index", "Home");

			}

			return View(reg);
		}

		
	}
}