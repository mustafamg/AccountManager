using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;

namespace AccountManagement.Specs.steps
{
    class MyAccountDataList
    {

         private readonly IE _browser;
         public MyAccountDataList(IE browser)
        {
            _browser=browser;
        }
        public IEnumerable<Entry> DisplayedEntries
        {
            get
            {
                var entriesContainer = (IElementContainer)_browser.Element("entries");
                return from li in entriesContainer.ElementsWithTag("li")
                       select new Entry { Container = li as IElementContainer };
            }
        }

        public class Entry
        {
            public IElementContainer Container { get; internal set; }

            /*row["name"] == entry.Name
                        && row["email"] == entry.Email
                        && row["mobile"] == entry.Mobile
                        && row["gender"] == entry.Gender*/

            public string Name { get { return this["name"]; } }
            public string Password { get { return this["password"]; } }
            public string Email { get { return this["email"]; } }
            public string Mobile { get { return this["mobile"]; } }
            public string Gender { get { return this["gender"]; } }
            public string Activated { get { return this["activated"]; } }

            public string this[string key]
            {
                get { return Container.Element(Find.ById(key)).Text; }
            }
        }
    }
    
}
