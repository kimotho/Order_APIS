using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public OrdersController(DataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        // GET: api/orders
        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            List<Order> orders = _dataAccessLayer.GetOrders();
            return Ok(orders);
        }

        // POST: api/orders
        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            _dataAccessLayer.CreateOrder(order);
            return Ok();
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _dataAccessLayer.UpdateOrder(order);
            return Ok();
        }
        [HttpGet("customerOrders")]
        public IActionResult GetCustomerOrders(int customerID)
        {
            var customerOrders = _dataAccessLayer.GetOrders()
            
                .Where(o => o.CustomerID == customerID) // Filter orders by CustomerID
                .Select(o => new
                {
                    OrderID = o.OrderID,
                    OrderDescription = o.OrderDescription,
                    ItemDescription = o.ItemDescription,
                })
                .ToList();

            return Ok(customerOrders);
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            Order order = _dataAccessLayer.GetOrders().FirstOrDefault(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            _dataAccessLayer.DeleteOrder(order);
            return Ok();
        }
    }

}
