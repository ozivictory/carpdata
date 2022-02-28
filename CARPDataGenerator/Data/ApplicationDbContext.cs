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
        public DbSet<FTR> FTR { get; set; }
        public DbSet<STR> TRANSACTIONS { get; set; }


        public DbSet<TransactionSignatoryOrDirector> TransactionSignatoryOrDirector { get; set; }
        public DbSet<TransactionPersonIdentification> TransactionPersonIdentification { get; set; }



        // Lookup Values Table
        public DbSet<ContactType> LookupContactType { get; set; }
        public DbSet<CommunicationType> LookupCommunicationType { get; set; }
        public DbSet<IdentifierType> LookupIdentifierType { get; set; }
        public DbSet<CountryCodes> LookupCountryCodes { get; set; }
        public DbSet<ConductionType> LookupConductionType { get; set; }
        public DbSet<FundsType> LookupFundsType { get; set; }
        public DbSet<Currencies> LookupCurrencies { get; set; }
        public DbSet<AccountType> LookupAccountType { get; set; }
        public DbSet<EntityLegalFormType> LookupEntityLegalFormType { get; set; }
        public DbSet<AccountStatusType> LookupAccountStatusType { get; set; }
        public DbSet<IndicatorType> LookupIndicatorType { get; set; }
    }
}
