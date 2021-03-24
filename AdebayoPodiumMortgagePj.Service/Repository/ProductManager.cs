using AdebayoPodiumMortgagePj.Data.Models;
using AdebayoPodiumMortgagePj.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdebayoPodiumMortgagePj.Service.Repository
{
    public class ProductManager:IProductManager
    {
        private readonly ICustomerManager _customerManager;

        public ProductManager(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public ManagerResponse<IEnumerable<Product>> GetCustomerProducts(Mortgage mortgage)
        {
            var time = DateTime.UtcNow;

            if (mortgage.Customer.Id == null)
            {
                return new ManagerResponse<IEnumerable<Product>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Enter Customer id!",
                    Time = time
                };
            }

            if (mortgage.DepositAmount <= 0 || mortgage.PropertyValue <= 0)
            {
                return new ManagerResponse<IEnumerable<Product>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Enter a value greater than 0",
                    Time = time
                };
            }

            var customerData = _customerManager.GetCustomerWithId(mortgage.Customer.Id);

            if (customerData.Data == null)
            {
                return new ManagerResponse<IEnumerable<Product>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = $"Customer with id {mortgage.Customer.Id} not found! Please register!",
                    Time = time
                };
            }

            var customerAge = DateTime.UtcNow.Year - customerData.Data.DateOfBirth.Year;

            if(customerAge < 18)
            {
                return new ManagerResponse<IEnumerable<Product>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "You need to be at least 18 years to apply!",
                    Time = time
                };
            }

            var products = GetAllProducts().ToList();
            var customerLoanToValue = CalculateLoanToValueRatio(mortgage);

            if (customerLoanToValue > 90)
            {
                return new ManagerResponse<IEnumerable<Product>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = $"Your loan to value is too high at {customerLoanToValue}%! Consider increasing your deposit.",
                    Time = time
                };
            }

            var customerProducts = products.Where(p => p.BaseLoanToValue <= customerLoanToValue).ToList();

            if(!customerProducts.Any())
            {
                return new ManagerResponse<IEnumerable<Product>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Sorry! No matching products!",
                    Time = time
                };
            }

            return new ManagerResponse<IEnumerable<Product>>
            {
                Data = customerProducts,
                IsSuccess = true,
                Message = $"Available products for a LoanToValue of {customerLoanToValue}%",
                Time = time
            };
        }

        private static double CalculateLoanToValueRatio(Mortgage mortgage)
        {
            var loanToValue = (mortgage.PropertyValue - mortgage.DepositAmount) / mortgage.PropertyValue;
            return Math.Round(decimal.ToDouble(loanToValue * 100));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    InterestRate = "2%",
                    BaseLoanToValue = 60,
                    InterestType = "Variable",
                    Lender = new Lender
                    {
                        Id = 1,
                        Name = "Bank A",
                    }
                },
                new Product
                {
                    Id = 2,
                    InterestRate = "3%",
                    BaseLoanToValue = 60,
                    InterestType = "Fixed",
                    Lender = new Lender
                    {
                        Id = 1,
                        Name = "Bank B",
                    }
                },
                new Product
                {
                    Id = 3,
                    InterestRate = "4%",
                    BaseLoanToValue = 90,
                    InterestType = "Variable",
                    Lender = new Lender
                    {
                        Id = 1,
                        Name = "Bank C",
                    }
                }
            };
        }
    }
}
