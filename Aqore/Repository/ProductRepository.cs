using Aqore.Data;
using Aqore.Models.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Aqore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> ProductsFromStoredProcedure()
        {
            var obj= _context.Products.FromSqlRaw("EXEC GetProducts");
            return (obj);
        }

        public IEnumerable<Product> ProductFromStoredProcedure(int productId)
        {
            var parameter = new SqlParameter("@productId", productId);
            return _context.Products.FromSqlRaw("EXEC GetProductById @productId", parameter);
        }

        public void CreateProduct(string name, string description, int price)
        {
            var nameParameter = new SqlParameter("@name", name);
            var descriptionParameter = new SqlParameter("@description", description);
            var priceParameter = new SqlParameter("@price", price);
            //var inStockParameter = new SqlParameter("@inStock", inStock);

             _context.Products.FromSqlRaw("EXEC CreateProduct @name, @description, @price", nameParameter, descriptionParameter, priceParameter);
        }

        public void UpdateProduct(string product, string description, int price)
        {
            var nameParameter = new SqlParameter("@product", product);
            var descriptionParameter = new SqlParameter("@description", description);
            var priceParameter = new SqlParameter("@price", price);
            //var inStockParameter = new SqlParameter("@inStock", inStock);

             _context.Products.FromSqlRaw("EXEC UpdateProduct @product, @description, @price", nameParameter, descriptionParameter, priceParameter);
        }

        public void DeleteProduct(int productId)
        {
            var productIdParameter = new SqlParameter("@productId", productId);
             _context.Products.FromSqlRaw("EXEC DeleteProduct @productId", productIdParameter);
        }

    }
}



