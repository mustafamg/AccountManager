using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace AccountManagement.Specs.Infrastructure
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IE _browser;
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        [BeforeScenario]
        public void Before()
        {
            _browser = new IE();
            _objectContainer.RegisterInstanceAs(_browser);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            _browser.Dispose();
        }
    }
}
