using MongoDB.Driver;
using SuperMarketApplication.Model;
using System;

namespace SuperMarketApplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        
        private readonly IMongoCollection<Product> db;
        public ProductRepository(IMongoClient client) {
            var connection = client.GetDatabase("SuperMarket");
            var collection = connection.GetCollection<Product>(nameof(Product));
            db = collection;
        }

        public async Task<int> AddNewProduct(Product product)
        {
            await db.InsertOneAsync(product);
            return product.ProductId;
        }

        public async Task<bool> DeleteProductById(int productId)
        {
            var queryData = Builders<Product>.Filter.Eq(e => e.ProductId, productId);
            var result = await db.DeleteOneAsync(queryData);
            return result.DeletedCount == 1;

        }

        public async Task<List<Product>> FetchAllProducts()
        {
            return await db.Find(e => true).ToListAsync();
        }

        public async Task<List<Product>> FetchProductByName(string productName)
        {
            var queryData = Builders<Product>.Filter.Eq(e => e.Name, productName);
            return await db.Find(queryData).ToListAsync();
        }

        public async Task<bool> UpdateProductDetails(int productId, Product product)
        {
            var queryData = Builders<Product>.Filter.Eq(e => e.ProductId, productId);
            var updateData = Builders<Product>.Update
                .Set(e => e.Name, product.Name)
                .Set(e => e.Description, product.Description)
                .Set(e => e.Category, product.Category)
                .Set(e => e.Price, product.Price)
                .Set(e => e.Price, product.Price)
                .Set(e => e.PriceTotal, product.PriceTotal)
                .Set(e => e.Quantity, product.Quantity);

            var result = await db.UpdateOneAsync(queryData, updateData);
            return result.ModifiedCount == 1;
                
        }
    }
}

