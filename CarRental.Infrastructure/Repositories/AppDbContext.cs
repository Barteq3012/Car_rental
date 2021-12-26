using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<RegistrationProof> RegistrationProof { get; set; }
        public DbSet<Rent> Rent { get; set; }

    }
}
