using System;
using System.Collections.Generic;
using System.Data.Entity;
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

		public static List<Product> GetProductByPage(int page, byte pageSize)
		{
			//database instance
			CommereceDBContext context = new CommereceDBContext();
			List<Product> prodList = context
									.Products
									.Take(pageSize)        // get all products from context but take a PageSize amount only
									.OrderBy(p => p.Name)
									.Skip((page - 1) * pageSize)     // skips the amount of PageSize allowed by what page you are on.
									.ToList();  // gets all products and turns it into a list.

			return prodList;
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

		public static void Update(Product p)
		{
			var context = new CommereceDBContext();

			//Tell EF this product has only been modified
			//It's already in the database
			context.Entry(p).State = EntityState.Modified;
			//Send Update query to the DB
			context.SaveChanges();
		}

		public static Product GetProductById(int id)
		{
			CommereceDBContext context = new CommereceDBContext();
			//finds a single product by its id number
			Product p = context.Products.Find(id);
			return p;
			

		}
	}
}