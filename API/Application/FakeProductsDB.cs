using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class FakeProductDB
	{
		private static List<Product> _products;

		public FakeProductDB()
		{
			_products = new List<Product>
			{
				new Product { Id = 1, Name = "Product 1", Code = "Product1", Price = 1.00m },
				new Product { Id = 2, Name = "Product 2", Code = "Product2", Price = 2.02m },
				new Product { Id = 3, Name = "Product 3", Code = "Product3", Price = 3.03m }
			};
		}

		public async Task AddProduct(Product product)
		{
			_products.Add(product);
			await Task.CompletedTask;
		}

		public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

		public async Task<Product> GetProductById(int id) =>
			await Task.FromResult(_products.Single(p => p.Id == id));
	}
}
