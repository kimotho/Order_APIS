using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1
{
    public class DataAccessLayer
    {
        private readonly AppDbContext _context;

        public DataAccessLayer(AppDbContext context)
        {
            _context = context;
        }

        // Retrieve a list of customers
        public List<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
        }

        // Create a new order
        public void CreateOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
        }
        // Create a new cust
        public void CreateCustomer(Customer cust)
        {
            _context.Customer.Add(cust);
            _context.SaveChanges();
        }

        // Retrieve a list of orders
        public List<Order> GetOrders()
        {
            return _context.Order.ToList();
        }
        // Update an existing cust
        public void UpdateCustomer(Customer order)
        {
            _context.Customer.Update(order);
            _context.SaveChanges();
        }

        // Update an existing order
        public void UpdateOrder(Order order)
        {
            _context.Order.Update(order);
            _context.SaveChanges();
        }

        // Delete an order
        public void DeleteOrder(Order order)
        {
            _context.Order.Remove(order);
            _context.SaveChanges();
        }
        // Delete an order
        public void DeleteCustomer(Customer order)
        {
            _context.Customer.Remove(order);
            _context.SaveChanges();
        }
        public void GetCustomerOrders(Customer order)
        {
            _context.Customer.Remove(order);
            _context.SaveChanges();
        }


    }

}
