using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.Model.DAL
{
    public interface IMainModuleContext
	{
	    IDbSet<Account> account { get; set; } // My collections...
	    IDbSet<TEntity> Set<TEntity>() where TEntity : class;
	    void SaveChanges();
	}
}
