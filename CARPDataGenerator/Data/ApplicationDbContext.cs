using CARPDataGenerator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CARPDataGenerator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CTR> CTR { get; set; }
        public DbSet<TransactionSignatoryOrDirector> TransactionSignatoryOrDirector { get; set; }
        public DbSet<TransactionPersonIdentification> TransactionPersonIdentification { get; set; }

        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<CommunicationType> CommunicationType { get; set; }
        public DbSet<IdentifierType> IdentifierType { get; set; }
        public DbSet<CountryCodes> CountryCodes { get; set; }
    }
}
