using AdebayoPodiumMortgagePj.Data.Models;
using AdebayoPodiumMortgagePj.Service.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdebayoPodiumMortgagePj.Service.IRepository
{
    public interface ICustomerManager
    {
        ManagerResponse<IEnumerable<Customer>> GetAllCustomers();
        ManagerResponse<Customer> GetCustomerWithId(string id);
        Task<ManagerResponse<Customer>> CreateCustomer(Customer customer);
    }
}
