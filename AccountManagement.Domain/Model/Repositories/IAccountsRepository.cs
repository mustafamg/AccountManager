using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.Model;

namespace AccountManagement.Domain.Repositories
{
    public interface IAccountsRepository : IRepository<Account>
    {
        //new functionality
    }
}
