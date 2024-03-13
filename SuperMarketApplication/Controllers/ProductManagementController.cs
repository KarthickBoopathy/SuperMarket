using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarketApplication.Model;
using SuperMarketApplication.Repository;
using SuperMarketApplication.Service;

namespace SuperMarketApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductManagementController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductManagementController(IProductService productService) {
            _productService = productService;
        }

        [HttpGet("/fetchAllProducts")]
        public async Task<IActionResult> getAllProducts()
        {
            return new JsonResult(await _productService.GetAllProducts() );
        }

        [HttpGet("/fetchProductByName/{productName}")]
        public async Task<IActionResult> getProductByName(string productName)
        {
            return new JsonResult(await _productService.GetProductByName(productName));
        }

        [HttpPost("/AddProduct")]
        public async Task<IActionResult> addProduct(Product product)
        {
            return  new JsonResult(await _productService.CreateProduct(product));
        }

        [HttpPut("/UpdateProduct/{productId}")]
        public async Task<IActionResult> updateProduct(int productId, Product product)
        {
            return new JsonResult(await _productService.UpdateProduct(productId, product));
        }

        [HttpDelete("/DeleteProductByName/{productId}")]
        public async Task<IActionResult> deleteProduct(int productId)
        {
            return new JsonResult(await _productService.RemoveProductById(productId));
        }
    }
}
