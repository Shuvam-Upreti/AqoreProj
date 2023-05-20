using Aqore.Data;
using Aqore.Models.Domain;
using Aqore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _unitOfWork.Product.ProductsFromStoredProcedure();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _unitOfWork.Product.ProductFromStoredProcedure(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            int price = Convert.ToInt32(product.Price);

            _unitOfWork.Product.CreateProduct(product.Name, product.Description,price);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var existingProduct = _unitOfWork.Product.ProductFromStoredProcedure(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            int price = Convert.ToInt32(product.Price);
            _unitOfWork.Product.UpdateProduct(product.Name, product.Description, price);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = _unitOfWork.Product.ProductFromStoredProcedure(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.DeleteProduct(id);
            return Ok();
        }
    }
}

