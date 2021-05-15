using System.Collections.Generic;
using System.Linq;
using Model = StoreModels;
using Entity = StoreDL.Entities;

namespace StoreDL
{
    public class RepoDB : IRepository
    {
        private Entity.MochaMomentDBContext _context;
        public RepoDB(Entity.MochaMomentDBContext context) {
            _context = context;
        }
        public Model.Customer AddCustomer(Model.Customer customer)
        {
            _context.Customers.Add(
                new Entity.Customer {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Birthdate = customer.Birthdate,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                MailAddress = customer.MailAddress
                }
            );
            _context.SaveChanges();
            return customer;
        }


        public Model.LineItem AddLineItem(Model.LineItem lineItem)
        {
            throw new System.NotImplementedException();
        }

        public Model.Location AddLocation(Model.Location location)
        {
            throw new System.NotImplementedException();
        }

        public Model.Order AddOrder(Model.Order order)
        {
            throw new System.NotImplementedException();
        }

        public Model.Product AddProduct(Model.Product product)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(customer =>
                new Model.Customer(customer.FirstName, customer.LastName, customer.Birthdate, customer.PhoneNumber, customer.Email, customer.MailAddress)
            ).ToList();
        }

        public List<Model.Inventory> GetAllInventories()
        {
            throw new System.NotImplementedException();
        }

        public List<Model.LineItem> GetAllLineItems()
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Location> GetAllLocations()
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Order> GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Product> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public Model.Customer GetCustomer(Model.Customer customer)
        {
            Entity.Customer found = _context.Customers.FirstOrDefault(custo => custo.FirstName == customer.FirstName && custo.LastName == customer.LastName && custo.Birthdate == customer.Birthdate && custo.PhoneNumber == customer.PhoneNumber && custo.Email == customer.Email && custo.MailAddress == customer.MailAddress);
            if (found == null) {
                return null;
            }
            return new Model.Customer(found.FirstName, found.LastName, found.Birthdate, found.PhoneNumber, found.Email, found.MailAddress);
        }

        public Model.LineItem GetLineItem(Model.LineItem lineItem)
        {
            throw new System.NotImplementedException();
        }

        public Model.Location GetLocation(Model.Location location)
        {
            throw new System.NotImplementedException();
        }

        public Model.Product GetProduct(Model.Product product)
        {
            throw new System.NotImplementedException();
        }

        public Model.Inventory UpdateInventory(Model.Inventory inventory)
        {
            throw new System.NotImplementedException();
        }

        public Model.Order ViewOrder(Model.Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}