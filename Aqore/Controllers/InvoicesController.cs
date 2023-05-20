using Aqore.Data;
using Aqore.Models.Domain;
using Aqore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = _unitOfWork.Invoice.InvoicesFromStoredProcedure();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var invoice = _unitOfWork.Invoice.InvoiceFromStoredProcedure(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public IActionResult CreateInvoice(Invoice invoice)
        {
            _unitOfWork.Invoice.CreateInvoice(invoice.InvoiceDate, invoice.TotalAmount);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInvoice(int id, Invoice invoice)
        {
            var existingInvoice = _unitOfWork.Invoice.InvoiceFromStoredProcedure(id);
            if (existingInvoice == null)
            {
                return NotFound();
            }

            _unitOfWork.Invoice.UpdateInvoice(invoice.InvoiceDate, invoice.TotalAmount);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            var existingInvoice = _unitOfWork.Invoice.InvoiceFromStoredProcedure(id);
            if (existingInvoice == null)
            {
                return NotFound();
            }

            _unitOfWork.Invoice.DeleteInvoice(id);
            return Ok();
        }
    }
}

