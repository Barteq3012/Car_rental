﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        public Task Add(CreateCustomer customer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateCustomer customer, int id)
        {
            throw new NotImplementedException();
        }
    }
}
