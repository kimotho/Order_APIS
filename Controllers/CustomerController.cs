using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [ControllerName("Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataAccessLayer _dataAccessLayer;
        public CustomerController(DataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        // GET: api/customers
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            List<Customer> cust = _dataAccessLayer.GetCustomers();
            return Ok(cust);
        }

        // POST: api/customers
        [HttpPost]
        public ActionResult CreateCustomers(Customer order)
        {
            _dataAccessLayer.CreateCustomer(order);
            return Ok();
        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCustomers(int id, Customer order)
        {
            if (id != order.CustomerID)
            {
                return BadRequest();
            }

            _dataAccessLayer.UpdateCustomer(order);
            return Ok();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            Customer order = _dataAccessLayer.GetCustomers().FirstOrDefault(o => o.CustomerID == id);
            if (order == null)
            {
                return NotFound();
            }

            _dataAccessLayer.DeleteCustomer(order);
            return Ok();
        }
    }
}
