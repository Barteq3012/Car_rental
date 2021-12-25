﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> BrowseAll();
    }
}