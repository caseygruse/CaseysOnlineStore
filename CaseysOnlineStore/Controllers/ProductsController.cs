using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseysOnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            //Should show user list of all products
            return View();
        }

        /// <summary>
        /// returns web page that allows the creation of products
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }
    }
}