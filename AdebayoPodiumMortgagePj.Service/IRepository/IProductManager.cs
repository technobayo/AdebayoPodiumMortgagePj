using AdebayoPodiumMortgagePj.Data.Models;
using AdebayoPodiumMortgagePj.Service.Repository;
using System.Collections.Generic;

namespace AdebayoPodiumMortgagePj.Service.IRepository
{
    public interface IProductManager
    {
        IEnumerable<Product> GetAllProducts();
        ManagerResponse<IEnumerable<Product>> GetCustomerProducts(Mortgage mortgage);
    }
}
