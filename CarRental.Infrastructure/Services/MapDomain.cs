using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Core.Domain;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    static class MapDomain
    {
        static public RentDTO mapRentToDTO(Rent r)
        {
            if (r == null)
            {
                return null;
            }
            else
            {
                var rDTO = new RentDTO()
                {
                    Id = r.Id,
                    Car = mapCarToDTO(r.Car),
                    Customer = mapCustomerToDTO(r.Customer),
                    RentDate = r.RentDate,
                    ReturnDate = (DateTime)r.ReturnDate,
                    TotalCost = r.TotalCost
                };
                return rDTO;
            }
        }

        static public CustomerDTO mapCustomerToDTO(Customer c)
        {
            if (c == null)
            {
                return null;
            }
            else
            {
                var cDTO = new CustomerDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    SecondName = c.SecondName,
                    BirthDate = c.BirthDate,
                    Country = c.Country,
                    Company = mapCompanyToDTO(c.Company)
                };
                return cDTO;
            }
        }

        static public CompanyDTO mapCompanyToDTO(Company c)
        {
            if (c == null)
            {
                return null;
            }
            else
            {
                var cDTO = new CompanyDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    Country = c.Country
                };
                return cDTO;
            }
        }

        static public RegistrationProofDTO mapRegistrationProofToDTO(RegistrationProof r)
        {
            if (r == null)
            {
                return null;
            }
            else
            {
                var rDTO = new RegistrationProofDTO()
                {
                    Id = r.Id,
                    FirstRegistrationDate = r.FirstRegistrationDate,
                    Plate = r.Plate
                };
                return rDTO;
            }
        }

        static public CarDTO mapCarToDTO(Car c)
        {
            if (c == null)
            {
                return null;
            }
            else
            {
                var cDTO = new CarDTO()
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ProductionDate = c.ProductionDate,
                    Country = c.Country,
                    Mileage = c.Mileage,
                    RegistrationProof = mapRegistrationProofToDTO(c.RegistrationProof)
                };
                return cDTO;
            }
        }
    }
}
