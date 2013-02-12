using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using AccountManagement.Domain.Model;


namespace AccountManagement.Domain.Model
{

    public class AccountDatabaseInitializer : DropCreateDatabaseIfModelChanges<AccountDbContext>
    {
        protected override void Seed(AccountDbContext context)
        {
            //var accounts = new List<Account>
            //{
            //    new Account { Name = "Carson",Password="123" ,  Email = "Alexander", Mobile = "", Gender="",Activated=""  },
                
            //    new Account { Name = "Carson1",Password="1234" ,  Email = "Alexander1", Mobile = "", Gender="",Activated=""  } 
            //};
            //accounts.ForEach(s => context.Accounts.Add(s));
            //context.SaveChanges();
        }
    }

}
