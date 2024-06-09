using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WexAssessmentApi.Models;

namespace WexAssessmentApi.Repositories
{
    /// <summary>
    /// Repository for managing Product entities.
    /// </summary>
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        /// <summary>
        /// Gets products by category.
        /// </summary>
        /// <param name="category">Product category</param>
        /// <returns>List of products in the specified category</returns>
        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            var products = _store.Values.Where(p => p.Category == category);
            return Task.FromResult(products);
        }
    }
}


