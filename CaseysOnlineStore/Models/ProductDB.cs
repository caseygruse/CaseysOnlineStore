using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseysOnlineStore.Models
{
	public static class ProductDB
	{
		// if your class is static your methods should be static too.
		/// <summary>
		/// should return a list of all products from the products table.
		/// </summary>
		/// <returns>list of type products</returns>
		public static List<Product> GetAllProducts()
		{
			//linq query syntax to query the db. (Language Integrated Query)
			CommereceDBContext context = new CommereceDBContext();
			//Method 1: LINQ Query Syntax
			// basically saying for every p (product in products table)
			//what we are trying to do
			//SELECT * FROM Products ORDER BY Name
			List<Product> products = (from p in context.Products
									  orderby p.Name
									  select p).ToList();

			//METHOD 2: LINQ Method Syntax
			List<Product> products2 = context.Products.OrderBy(p => p.Name).ToList();
			return products;


		}

		// step 1. create a instance of the db
		// step 2. Add a pending object
		// step 3. execute the add using saveChanges();


		
		/// <summary>
		/// adds a product to the database using entity syntax.           //////////////////// REFERENCE
		/// </summary>
		/// <param name="p"></param>
		public static void AddProduct(Product p)
		{
			//1.
			//Create instance of DBContext class.
			//context is referencingthe DB
			CommereceDBContext context = new CommereceDBContext();
			//2.
			//Prepare insert statement
			//tells entity you want to add a product (p) to the database dosnt add it.
			context.Products.Add(p);
			// 3.
			//Execute pending insert    //the pending insert is what was done above with context.Products.Add(p)
			context.SaveChanges();
		}
	}
}