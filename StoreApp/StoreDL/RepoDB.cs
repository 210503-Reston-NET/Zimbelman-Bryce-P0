using System.Collections.Generic;
using System.Linq;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;

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


        public Model.LineItem AddLineItem(Model.LineItem lineItem, Model.Product product)
        {
            _context.LineItems.Add(
                new Entity.LineItem {
                    ProductId = lineItem.ProductID,
                    Quantity = lineItem.Quantity,
                    OrderId =lineItem.OrderID
                }
            );
            _context.SaveChanges();
            return lineItem;
        }

        public Model.Location AddLocation(Model.Location location)
        {
            _context.Locations.Add(
                new Entity.Location {
                    StoreName = location.StoreName,
                    Address = location.Address,
                    City = location.City,
                    State = location.State
                }
            );
            _context.SaveChanges();
            return location;
        }

        public Model.Order AddOrder(Model.Order order, Model.Location location, Model.Customer customer)
        {
            _context.Orders.Add(
                new Entity.Order {
                    LocationId = order.LocationID,
                    CustomerId = order.CustomerID,
                    Total = order.Total,
                    OrderDate = order.OrderDate
                }
            );
            _context.SaveChanges();
            return order;
        }

        public Model.Product AddProduct(Model.Product product)
        {
            _context.Products.Add(
                new Entity.Product {
                    ItemName = product.ItemName,
                    Price = product.Price,
                    Description = product.Description
                }
            );
            _context.SaveChanges();
            return product;
        }

        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(customer =>
                new Model.Customer(customer.CustomerId, customer.FirstName, customer.LastName, customer.Birthdate, customer.PhoneNumber, customer.Email, customer.MailAddress)
            ).ToList();
        }

        public List<Model.Inventory> GetAllInventories()
        {
            return _context.Inventories.Select(inventory =>
            new Model.Inventory(inventory.InventoryId, inventory.LocationId, inventory.ProductId, inventory.Quantity)
            ).ToList();
        }

        public List<Model.LineItem> GetAllLineItems()
        {
            return _context.LineItems.Select(lineItem => 
            new Model.LineItem(lineItem.ProductId, lineItem.Quantity, lineItem.OrderId)
            ).ToList();
        }

        public List<Model.Location> GetAllLocations()
        {
            return _context.Locations.Select(location =>
            new Model.Location(location.LocationId, location.StoreName, location.Address, location.City, location.State)
            ).ToList();
        }

        public List<Model.Order> GetAllOrders()
        {
            return _context.Orders.Select(order =>
            new Model.Order(order.LocationId, order.CustomerId, order.OrderId, order.Total, order.OrderDate)
            ).ToList();
        }

        public List<Model.Product> GetAllProducts()
        {
            return _context.Products.Select(product =>
            new Model.Product(product.ProductId, product.ItemName, product.Price, product.Description)
            ).ToList();
        }

        public Model.Customer GetCustomer(Model.Customer customer)
        {
            Entity.Customer found = _context.Customers.FirstOrDefault(custo => custo.FirstName == customer.FirstName && custo.LastName == customer.LastName && custo.Birthdate == customer.Birthdate && custo.PhoneNumber == customer.PhoneNumber && custo.Email == customer.Email && custo.MailAddress == customer.MailAddress);
            if (found == null) {
                return null;
            }
            return new Model.Customer(found.CustomerId, found.FirstName, found.LastName, found.Birthdate, found.PhoneNumber, found.Email, found.MailAddress);
        }

        public Model.LineItem GetLineItem(Model.LineItem lineItem)
        {
            Entity.LineItem found = _context.LineItems.FirstOrDefault( li => li.ProductId == lineItem.ProductID && li.Quantity == lineItem.Quantity && li.OrderId == lineItem.OrderID);
            if (found == null) {
                return null;
            }
            return new Model.LineItem(found.LineItemId, lineItem.ProductID, found.Quantity, found.OrderId);
        }

        public Model.Location GetLocation(Model.Location location)
        {
            Entity.Location found = _context.Locations.FirstOrDefault(loca => loca.StoreName == location.StoreName && loca.Address == location.Address && loca.City == location.City && loca.State == location.State);
            if (found == null) {
                return null;
            }
            return new Model.Location(found.LocationId, found.StoreName, found.Address, found.City, found.State);
        }

        public Order GetOrder(Order order)
        {
            Entity.Order found = _context.Orders.FirstOrDefault(ord => ord.LocationId == order.LocationID && ord.CustomerId == order.CustomerID && ord.OrderId == order.OrderID && ord.Total == order.Total && ord.OrderDate == order.OrderDate);
            if (found == null) {
                return null;
            }
            return new Model.Order(found.OrderId , order.LocationID, order.CustomerID, found.OrderId, found.Total, found.OrderDate);
        }

        public Model.Product GetProduct(Model.Product product)
        {
            Entity.Product found = _context.Products.FirstOrDefault(prod => prod.ItemName == product.ItemName && prod.Price == product.Price && prod.Description == product.Description);
            if (found == null) {
                return null;
            }
            return new Model.Product(found.ProductId, found.ItemName, found.Price, found.Description);
        }

        public Inventory GetStoreInventory(Model.Inventory inventory)
        {
            Entity.Inventory found = _context.Inventories.FirstOrDefault(inven => inven.LocationId == inventory.LocationID && inven.ProductId == inventory.ProductID && inven.Quantity == inventory.Quantity);
            if (found == null) {
                return null;
            }
            return new Model.Inventory(found.InventoryId, inventory.LocationID, inventory.ProductID, found.Quantity);
        }

        public Model.Inventory AddInventory(Model.Inventory inventory, Model.Location location, Model.Product product)
        {
            _context.Inventories.Add(
                new Entity.Inventory {
                    InventoryId = inventory.Id,
                    LocationId = GetLocation(location).Id,
                    ProductId = GetProduct(product).Id,
                    Quantity = inventory.Quantity
                    }
                );
                _context.SaveChanges();
                return inventory;
        }

        public Inventory UpdateInventory(Model.Inventory inventory, Model.Location location, Model.Product product)
        {
            Entity.Inventory updateInventory = _context.Inventories.Single(inven => inven.InventoryId == inventory.Id);
            updateInventory.Quantity = inventory.Quantity;
            _context.SaveChanges();
            return inventory;
        }

                public Model.Order UpdateOrder(Model.Order order, Model.Location location, Model.Customer customer) {
                    Entity.Order updateOrder = _context.Orders.Single(ord => ord.OrderId == order.OrderID);
                    updateOrder.Total = order.Total;
                    _context.SaveChanges();
                    return order;
        }
    }
}