using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseysOnlineStore.Models
{
	public static class ShoppingCart
	{
		/// <summary>
		/// Returns total number of items in cart.
		/// Includes duplicate products.
		/// </summary>
		/// <returns></returns>
		public static short GetTotalItems()
		{
			//gets the list of products from the cookies
			List<Product> products = GetProducts();

			short numProducts = 0;
			//loop through the proudct list and grab all items
			// using .quanity so you can get duplicate items as well.
			foreach (Product p in products)
			{
				numProducts += p.Quanity;
			}
			return numProducts;
		}

		public static List<Product> GetProducts()
		{
			//makes a list of products
			List<Product> prods = new List<Product>();
			// get all the cookies from the cart with a name of cart (cart is the name the cart items have.)
			HttpCookie cartCookie = HttpContext.Current.Request.Cookies["cart"];
			//if there are no items in the cart it will be an empty list
			if (cartCookie == null)
				return prods;
			//uncodes the json and puts it in the list of prods
			prods = JsonConvert.DeserializeObject<List<Product>>(cartCookie.Value);
			return prods;
		}

		public static void AddProduct(Product p)
		{
			List<Product> products = new List<Product>();
			products.Add(p);

			//get string for the object you are adding to cart
			string jsonData = JsonConvert.SerializeObject(products);
			//create a cookie and named it cart
			HttpCookie cookie = new HttpCookie("cart");
			//adding the item to the cookie
			cookie.Value = jsonData;
			//setting a five year experation date for the cookie.
			cookie.Expires = DateTime.Now.AddYears(5);
			//current request letting you know where to put the cookie.
			HttpContext.Current.Response.Cookies.Add(cookie);
		}
	}
}