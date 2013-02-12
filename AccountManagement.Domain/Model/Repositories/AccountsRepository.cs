using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.Model;

namespace AccountManagement.Domain.Repositories
{


    public class AccountsRepository : EFRepository<Account>, IAccountsRepository
    {
      
        public AccountsRepository(DbContext context) : base(context) { }

      
        /// <summary>
        /// Get <see cref="Speaker"/>s at sessions.
        /// </summary>
        ///<remarks>
        ///See <see cref="IPersonsRepository.GetSpeakers"/> for details.
        ///</remarks>

       /* public IQueryable<Speaker> GetSpeakers()
        {
            

        }*/
    }
}
