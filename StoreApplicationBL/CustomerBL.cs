using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApplicationEntities;
using StoreApplicationDL;

namespace StoreApplicationBL
{
    public class CustomerBL
    {
        private readonly IDatabase<Customer> _customerDB;
        private readonly IList<string> _includes;

        public CustomerBL(IDatabase<Customer> p_customerDB)
        {
            _customerDB = p_customerDB;
            _includes = new List<string>();
        }

        public async Task<Customer> CreateCustomerAsync(Customer p_customer)
        {
            return await _customerDB.Create(p_customer);
        }

        public async Task<Customer> GetCustomerAsync(string p_customerId)
        {
            if (p_customerId == null)
            {
                throw new ArgumentException("Missing parameter customerId");
            }

            return await _customerDB.FindSingle(new()
            {
                Conditions = new List<Func<Customer, bool>>
                {
                    c => c.Id == int.Parse(p_customerId)
                },
                Includes = _includes
            }) ;
        }

        public async Task<Customer> GetCustomerAsync(Customer p_customer)
        {
            if (p_customer.Id == null)
            {
                throw new ArgumentException("Missing parameter customerId");
            }

            return await _customerDB.FindSingle(new()
            {
                Conditions = new List<Func<Customer, bool>>
                {
                    c => c.Id == p_customer.Id
                },
                Includes = _includes
            });
        }

        public async Task<bool> SaveUserAsync()
        {
            return await _customerDB.Save();
        }

        public async Task<Customer> EditProfileAsync(Customer p_customer)
        {
            Customer targetCustomer = await this.GetCustomerAsync(p_customer);

            if (targetCustomer == null)
            {
                throw new ArgumentException($"Unable to find customer with given id \"{p_customer.Id}\"");
            }

            targetCustomer.Email = p_customer.Email;
            targetCustomer.Phone = p_customer.Phone;
            targetCustomer.Lname = p_customer.Lname;
            targetCustomer.Fname = p_customer.Fname;
            targetCustomer.Address = p_customer.Address;
            targetCustomer.City = p_customer.City;
            targetCustomer.State = p_customer.State;

            await _customerDB.Save();
            return targetCustomer;
        }
    }
}
