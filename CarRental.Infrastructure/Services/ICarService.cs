﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> BrowseAll();
    }
}
