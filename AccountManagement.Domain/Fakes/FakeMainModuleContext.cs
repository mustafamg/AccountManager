//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace AccountManagement.Domain.Model.DAL
//{
    
//public partial class FakeMainModuleContext :IMainModuleContext
//{
//    public IDbSet<Account> account { get; set; }
//    public IDbSet<T> Set<T>() where T : class
//    {
//        foreach (PropertyInfo property in typeof(FakeMainModuleContext).GetProperties())
//        {
//            if (property.PropertyType == typeof(IDbSet<T>))
//                return property.GetValue(this, null) as IDbSet<T>;
//        }
//        throw new Exception("Type collection not found");
//    }

//    public void SaveChanges()
//    {
//         // do nothing (probably set a variable as saved for testing)
//    }

//    public FakeMainModuleContext()
//    {
//        // Set up your collections
//        account = new FakeDbSet {new Account() { Name = "Nehad" }
//        };
//    }


//}
