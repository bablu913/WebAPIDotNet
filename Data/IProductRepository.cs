using WebAPIDemo.Models;
namespace WebAPIDemo.Data
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task<Product?> UpdateProductPrice(int id, double newPrice);
        public Task<bool> CreateProduct(Product product);
        public Task<bool> DeleteProduct(int id);
    }
}
