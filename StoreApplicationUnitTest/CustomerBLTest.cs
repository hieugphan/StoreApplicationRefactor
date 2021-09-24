using Microsoft.EntityFrameworkCore;
using StoreApplicationDL;
using StoreApplicationBL;
using StoreApplicationEntities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StoreApplicationUnitTest
{
    public class CustomerBLTest
    {
        private readonly DbContextOptions<StoreApplicationDbContext> _options;

        public CustomerBLTest()
        {
            _options = new DbContextOptionsBuilder<StoreApplicationDbContext>().UseSqlite("Filename = customerBL_test.db").Options;
            this.Seed();
        }

        private void Seed()
        {
            using (var context = new StoreApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new()
                    {
                        Id = 1,
                        Email = "hieu.g.phan@gmail.com"
                    },
                    new()
                    {
                        Id = 2,
                        Email = "hieu.g.phan2@gmail.com"
                    },
                    new()
                    {
                        Id = 3,
                        Email = "hieu.g.phan3@gmail.com"
                    }
                );
                context.SaveChanges();
            }
        }

        [Fact]
        public async Task CreateNewCustomer()
        {
            using (var context = new StoreApplicationDbContext(_options))
            {
                //Arrange
                CustomerBL customerBL = new(new StoreApplicationDB<Customer>(context));

                await customerBL.CreateCustomerAsync(new()
                {
                    Id = 4,
                    Email = "hieu.g.phan4@gmail.com"
                });

                //Act
                Customer targetCustomer = context.Customers.Find(4);

                //Assert
                Assert.NotNull(targetCustomer);
                Assert.IsType<Customer>(targetCustomer);
                Assert.Equal("hieu.g.phan4@gmail.com", targetCustomer.Email);
            }
        }


    }
}
