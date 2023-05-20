using Aqore.Data;
using Aqore.Models.Domain;
using Aqore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var products = _unitOfWork.Customer.CustomersFromStoredProcedure();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _unitOfWork.Customer.CustomerFromStoredProcedure(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _unitOfWork.Customer.CreateCustomer(customer.Name, customer.Address);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = _unitOfWork.Customer.CustomerFromStoredProcedure(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _unitOfWork.Customer.UpdateCustomer(customer.Name, customer.Address);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var existingCustomer = _unitOfWork.Customer.CustomerFromStoredProcedure(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _unitOfWork.Customer.DeleteCustomer(id);
            return Ok();
        }
    }
}

