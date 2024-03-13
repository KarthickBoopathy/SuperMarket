using SuperMarketApplication.Model;
using SuperMarketApplication.Repository;

namespace SuperMarketApplication.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) { 
            _productRepository = productRepository;
        }

        public Task<int> CreateProduct(Product product)
        {
            return _productRepository.AddNewProduct(product);
        }

        public Task<List<Product>> GetAllProducts()
        {
            return _productRepository.FetchAllProducts();
        }

        public Task<List<Product>> GetProductByName(string productName)
        {
            return _productRepository.FetchProductByName(productName);
        }

        public Task<bool> RemoveProductById(int productId)
        {
            return _productRepository.DeleteProductById(productId);
        }

        public Task<bool> UpdateProduct(int productId, Product product)
        {
            return _productRepository.UpdateProductDetails(productId, product);
        }
    }
}
