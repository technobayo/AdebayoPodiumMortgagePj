using AdebayoPodiumMortgagePj.Data.Models;
using AdebayoPodiumMortgagePj.Service.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace AdebayoPodiumMortgagePj.Service.Repository
{
    public class CustomerManager : ICustomerManager
    {
        public string DataFilePath;
        public CustomerManager()
        {
            var buildPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DataFilePath = $"{buildPath}/Data/customer.json";
        }

        public ManagerResponse<IEnumerable<Customer>> GetAllCustomers()
        {
            var time = DateTime.UtcNow;

            try
            {
                var customers = GetCustomersFromFile();
                return new ManagerResponse<IEnumerable<Customer>>
                {
                    Data = customers,
                    IsSuccess = true,
                    Message = "Success!",
                    Time = time
                };
            }
            catch(Exception exception)
            {
                return new ManagerResponse<IEnumerable<Customer>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = $"Error getting all customer. {exception.StackTrace}",
                    Time = time
                };
            }
        }

        public ManagerResponse<Customer> GetCustomerWithId(string id)
        {
            var time = DateTime.UtcNow;

            var customers = GetCustomersFromFile();
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return new ManagerResponse<Customer>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = $"Error getting customer! Check id exists!",
                    Time = time
                };
            }
            return new ManagerResponse<Customer>
            {
                Data = customer,
                IsSuccess = true,
                Message = "Success!",
                Time = time
            };
        }

        public async Task<ManagerResponse<Customer>> CreateCustomer(Customer customer)
        {
            var time = DateTime.UtcNow;

            if (string.IsNullOrWhiteSpace(customer.FirstName)|| string.IsNullOrWhiteSpace(customer.LastName))
            {
                return new ManagerResponse<Customer>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = $"First name and last name required",
                    Time = time
                };
            }

            try
            {
                var customers = GetCustomersFromFile();
                customer.Id = Guid.NewGuid().ToString();
                var customersList = customers.ToList();
                customersList.Add(customer);
                await SaveFile(customersList);
                return new ManagerResponse<Customer>
                {
                    Data = customer,
                    IsSuccess = true,
                    Message = "Success!",
                    Time = time
                };
            }
            catch (Exception exception)
            {
                return new ManagerResponse<Customer>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = $"Error adding new customer. {exception.StackTrace}",
                    Time = time
                };
            }
        }

        private IEnumerable<Customer> GetCustomersFromFile()
        {
            var content = File.ReadAllText(DataFilePath);
            var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(content);
            return customers;
        }

        private async Task SaveFile(IEnumerable<Customer> customers)
        {
            try
            {
                var customersJson = JsonConvert.SerializeObject(customers);
                await File.WriteAllTextAsync(DataFilePath, customersJson);
            }
            catch(IOException exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
