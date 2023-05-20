using Aqore.Data;
using Aqore.Models.Domain;
using Aqore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SalesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetSalesTransactions()
        {
            var products = _unitOfWork.Sales.SalesTransactionsFromStoredProcedure();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetSalesTransactionById(int id)
        {
            var product = _unitOfWork.Sales.SalesTransactionFromStoredProcedure(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateSales(SalesTransaction salesTrasaction )
        {
            _unitOfWork.Sales.CreateSalesTransaction(salesTrasaction.TransactionDate, salesTrasaction.SoldQuantity);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSales(int id, SalesTransaction salesTransaction)
        {
            var existingSales = _unitOfWork.Sales.SalesTransactionFromStoredProcedure(id);
            if (existingSales == null)
            {
                return NotFound();
            }
            _unitOfWork.Sales.UpdateSalesTransaction(salesTransaction.TransactionDate, salesTransaction.SoldQuantity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSales(int id)
        {
            var existingSales = _unitOfWork.Sales.SalesTransactionFromStoredProcedure(id);
            if (existingSales == null)
            {
                return NotFound();
            }

            _unitOfWork.Sales.DeleteSalesTransaction(id);
            return Ok();
        }
    }
}

