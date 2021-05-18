using Entity = StoreDL.Entities;
using Model = StoreModels;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Collections.Generic;
using StoreDL;
using System.Linq;

namespace StoreTests
{
    public class RepoTest
    {
        private readonly DbContextOptions<Entity.MochaMomentDBContext> options;
        public RepoTest()
        {
            options = new DbContextOptionsBuilder<Entity.MochaMomentDBContext>().UseSqlite("Filename=Test.db").Options;
            Seed();
        }
        private void Seed() {
                using (var productContext = new Entity.MochaMomentDBContext(options)) {
                productContext.Database.EnsureDeleted();
                productContext.Database.EnsureCreated();
                productContext.Products.AddRange (
                    new Entity.Product {
                        ProductId = 1,
                        ItemName = "Mocha",
                        Price = 1.99,
                        Description = "Mocha?"
                    },
                    new Entity.Product
                    {
                        ProductId = 2,
                        ItemName = "Frost",
                        Price = 3.49,
                        Description = "Frost?"
                    }
                );
                productContext.SaveChanges();
            }
        }
        [Fact]
        public void GetAllProductsShouldReturnAllProducts() {
            using (var context = new Entity.MochaMomentDBContext(options)) {
                IRepository _repo = new RepoDB(context);
                var products = _repo.GetAllProducts();
                Assert.Equal(2, products.Count);
            }
        }

        [Fact]
        public void AddProductShouldAddProduct() {
            using (var context = new Entity.MochaMomentDBContext(options)) {
                IRepository _repo = new RepoDB(context);
                _repo.AddProduct(new Model.Product("Espresso", 1.99, "Espresso?"));
            }

            using (var assertContext = new Entity.MochaMomentDBContext(options)) {
                var result = assertContext.Products.FirstOrDefault(product => product.ProductId == 3);
                Assert.NotNull(result);
                Assert.Equal("Espresso", result.ItemName);
            }
        }
        [Fact]
        public void AddLineItemShouldAddLineItem() {
            using (var context = new Entity.MochaMomentDBContext(options)) {
                IRepository _repo = new RepoDB(context);
                _repo.AddCustomer(new Model.Customer("firstName", "lastName","birthdate", "phone#", "email", "Mailing Address"));
                _repo.AddLocation(new Model.Location("name", "address", "city", "state"));
                _repo.AddProduct(new Model.Product("name", 1.99, "description"));
                _repo.AddOrder(new Model.Order(1, 1, 1, 1.99, ""), new Model.Location("name", "address", "city", "state"), new Model.Customer("firstName", "lastName","birthdate", "phone#", "email", "Mailing Address"));
                _repo.AddLineItem(new Model.LineItem(1, 1, 1), new Model.Product("name", 1.99, "description"));
            }

            using (var assertContext = new Entity.MochaMomentDBContext(options)) {
                var result = assertContext.LineItems.FirstOrDefault(li => li.LineItemId == 1);
                Assert.NotNull(result);
                Assert.Equal(1, result.Quantity);
            }
        }
    }
}
