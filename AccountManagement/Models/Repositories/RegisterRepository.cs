using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountManagement.Models
{
    public class RegisterRepository:IRegisterRepository
    {
        

        private readonly List<RegisterEntry> _entries = new List<RegisterEntry> {
            new RegisterEntry {  Name = "Aya", Password="111", Email="aya@gmail.com",Mobile="00000", Gender='f', Activated= true}
        };
        public IQueryable<RegisterEntry> Entries
        {
            get
            {
                return _entries.AsQueryable();
            }
        }

        public bool UpdateEntry(RegisterEntry entry)
        {
            int index = _entries.FindIndex(e => e.Email == entry.Email);
            _entries.RemoveAt(index);
            _entries.Add(entry);
            return true;
        }


        public RegisterEntry Get(string email)
        {
            return _entries.Find(e => e.Email == email);
        }

        public void Remove(string email)
        {
            _entries.RemoveAll(e => e.Email == email);
        }
    }
}