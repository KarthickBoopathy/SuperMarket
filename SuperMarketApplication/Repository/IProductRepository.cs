using SuperMarketApplication.Model;

namespace SuperMarketApplication.Repository
{
    public interface IProductRepository
    {
        

        Task<List<Product>> FetchProductByName(string productName);
        Task<List<Product>> FetchAllProducts();
        Task<int> AddNewProduct(Product product);
        Task<bool> UpdateProductDetails(int productId, Product product);
        Task<bool> DeleteProductById(int productId);

    }
}
