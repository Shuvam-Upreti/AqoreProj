using Aqore.Models.Domain;

namespace Aqore.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> ProductsFromStoredProcedure();
        IEnumerable<Product> ProductFromStoredProcedure(int productId);
        void CreateProduct(string product, string description, int price);
        void UpdateProduct(string product, string description, int price);
        void DeleteProduct(int productId);
    }
}
