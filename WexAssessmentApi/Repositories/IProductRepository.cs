using System.Collections.Generic;
using System.Threading.Tasks;
using WexAssessmentApi.Models;

namespace WexAssessmentApi.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
    }
}
