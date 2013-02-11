using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountManagement.Models
{
    public interface IRegisterRepository
    {
         IQueryable<RegisterEntry> Entries { get; }
         bool UpdateEntry(RegisterEntry entry);
         RegisterEntry Get(string email);
         void Remove(string email);
    }
}