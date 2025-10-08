using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories;
        public ProductCategoryRepository()
        {
            productCategories = [
                new ProductCategory(1, "Melk", 1, 2),
                new ProductCategory(1, "Kaas", 2, 2),
                new ProductCategory(1, "Brood", 3, 1),
                new ProductCategory(1, "Cornflakes", 4, 3)];
        }
        public List<ProductCategory> GetAll()
        {
            return productCategories;
        }

        public ProductCategory? Get(int id)
        {
            return productCategories.FirstOrDefault(p => p.Id == id);
        }

        public ProductCategory Add(ProductCategory item)
        {
            productCategories.Add(item);
            return item;
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Update(ProductCategory item)
        {
            ProductCategory? ProductCategory = productCategories.FirstOrDefault(p => p.Id == item.Id);
            if (ProductCategory == null) return null;
            ProductCategory.Id = item.Id;
            return ProductCategory;
        }
    }
}
