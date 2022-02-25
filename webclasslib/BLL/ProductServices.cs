using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Additional Namespaces
using DAL;
using Entities;
using ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BLL
{
    public class ProductServices
    {
        #region Constructor Dependency Injection
        private readonly Context Context;
		public ProductServices(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}
        #endregion

        #region Queries
        public List<ProductList> FindProductsByPartialName(string partialName)
        {
            Console.WriteLine($"ProductServices: FindProductsByPartialName(); partialName= {partialName}");
            var info =
                Context.Products
                .Where(x => x.Description.Contains(partialName))
                .Select(x => new ProductList
                {
                    ProductId = x.ProductId,
                    ProductName = x.Description,
                    CategoryName = x.Category.Description,
                    UnitSize = x.UnitSize,
                    Price = x.Price,
                    Taxable = x.Taxable
                })
                .OrderBy(x => x.ProductName);
			    return info.ToList();
        }

        public List<ProductList> FindProductsByCategory(int? id)
		{
			Console.WriteLine($"ProductServices: FindProductsByCategory(); id= {id}");
			var info = 
				Context.Products
				.Where(x=>x.CategoryId == id)
				.Select(x => new ProductList
				{
					ProductId = x.ProductId,
                    ProductName = x.Description,
                    CategoryName = x.Category.Description,
                    UnitSize = x.UnitSize,
                    Price = x.Price,
                    Taxable = x.Taxable
				})
				.OrderBy(x => x.ProductName);
			    return info.ToList();
		}



        #endregion
    }
}