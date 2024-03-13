using SuperMarketApplication.Model;

namespace SuperMarketApplication.Service
{
    public interface IProductService
    {
        Task<int> CreateProduct(Product product);
        Task<bool> RemoveProductById(int productId);
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductByName(string productName);
        Task<bool> UpdateProduct(int productId, Product product);
    }
}
