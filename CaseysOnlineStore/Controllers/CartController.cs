using CaseysOnlineStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseysOnlineStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
		//Add gets its id from the product page when someone clicks add button for a product.
        public ActionResult Add(int id)
        {
			//add products to cart.
			Product p = ProductDB.GetProductById(id);
			//grabs the product when add button is clicked which passes its Id to getProducts by Id
			//the we serialize the product into a json string which we called cartData.
			string cartData = JsonConvert.SerializeObject(p);

			HttpCookie cookie = new HttpCookie("cart");
			cookie.Value = cartData;
			cookie.Expires = DateTime.Now.AddYears(5);
			Response.Cookies.Add(cookie);

            return View(p);
        }

		public ActionResult ViewCart()
		{
			//show user shopping cart contents
			throw new NotImplementedException();
		}
    }
}