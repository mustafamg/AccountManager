using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.Model;
using AccountManagement.Domain.Model.DAL;

namespace AccountManagement.Domain.Model
{
    public partial class AccountDbContext : DbContext//, IMainModuleContext
    {
        static AccountDbContext()
        {
            Database.SetInitializer(new AccountDatabaseInitializer());
        }

        public AccountDbContext() : base(nameOrConnectionString: "Account") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Account> Accounts { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}