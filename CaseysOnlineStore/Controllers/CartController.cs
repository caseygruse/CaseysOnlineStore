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
			//grabs the product when add button is clicked which passes its Id to getProducts by Id
			Product p = ProductDB.GetProductById(id);
			//the user is only adding a single product at a time.
			p.Quanity = 1;
			//the we serialize the product into a json string which we called cartData.
			ShoppingCart.AddProduct(p);

            return View(p);
        }

		public ActionResult ViewCart()
		{
			//show user shopping cart contents
			throw new NotImplementedException();
		}
    }
}