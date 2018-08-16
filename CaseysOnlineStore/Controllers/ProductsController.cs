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
		// int is getting passed in to index for url id is purposful its going to be used for pagenumber.
		// ? means it is nullable.             //making a page id with int perameter.
		[HttpGet]
        public ActionResult Index(int? id)
        {	

			int page = 1;
			//has value checks for null
			if (id.HasValue)
			{
				page = id.Value;
			}
			const byte PageSize = 2;

			//Show the user one page worth of products
			List<Product> prods = ProductDB.GetProductByPage(page, PageSize);

			int numProducts = ProductDB.GetTotalNumProducts();
			double maxPage = Math.Ceiling(numProducts / (double)PageSize);

			ViewBag.CurrentPage = page;
			ViewBag.MaxPage = maxPage;
			//ViewData["MaxPage"] = maxPage; // same as viewBag

			//teranary operator       // same as page code right above but more advanced . another way of writing if else;
			// int page = (id.HasValue) ? id.Value : 1;

			//same as page code right above but more advanced
			//null coalescing operator
			// int page = id ?? 1;

			//Should show user list of all products
			//List<Product> prods = ProductDB.GetAllProducts();
            return View(prods);
        }



		[HttpGet]
        /// <summary>
        /// returns web page that allows the creation of products
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
			//Should show user list of all products returned from productDB
			

			return View();
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

		[HttpGet]
		//perameter of id to the product you are looking to edit.
		public ActionResult Edit(int id)
		{
			Product prod = ProductDB.GetProductById(id);  // prod will equal 1 product that was found using its id.
			return View(prod);
		}

		[HttpPost]
		public ActionResult Edit(Product p)
		{
			if (ModelState.IsValid)
			{
				ProductDB.Update(p);
				return RedirectToAction("Index");
			}
			//if p is not valid then it will send you back to index with p
			return View(p);
			
		}

		

		[HttpGet]
		public ActionResult Delete(int id)
		{
			ProductDB.DeleteProduct(id);

			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			Product p = ProductDB.GetProductById(id);
			return View(p);
		}
    }
}