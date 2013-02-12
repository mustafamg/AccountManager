using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.Model;

namespace AccountManagement.Domain.Model
{
   

    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        /// <summary>
        /// Configure Data Exceplicit <see cref="AccountDbContext"/>
        /// </summary>
        /// <remarks>
        /// For more info <see cref="http://msdn.microsoft.com/en-US/data/jj591620"/>
        /// </remarks>
        public AccountConfiguration()
        {
            
           /* HasKey(a => new { a.SessionId, a.PersonId });
                  HasRequired(a => a.Session)
                .WithMany(s => s.AttendanceList)
                .HasForeignKey(a => a.SessionId)
                .WillCascadeOnDelete(false);*/
        }
    }
}
