using CaseysOnlineStore.Models;
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

		[HttpGet]
        /// <summary>
        /// returns web page that allows the creation of products
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
			//Should show user list of all products returned from productDB
			List<Product> products = ProductDB.GetAllProducts();

			return View(products);
        }
		[HttpPost]
		public ActionResult Create(Product p)
		{
			if (ModelState.IsValid)
			{
				ProductDB.AddProduct(p);
				return RedirectToAction("Index");
			}
			//if not valid valid return same view with with model and
			//invalid model state.
			return View(p);
			
		}
    }
}