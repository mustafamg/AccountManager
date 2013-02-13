using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using AccountManagement.Models;
using AccountManagement.Specs.Infrastructure;
using Moq;
using TechTalk.SpecFlow;
using WatiN.Core;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeleporterCore.Client;
using System.Collections.Generic;
using AccountManagement.Specs.steps;


namespace AccountManagement.Specs.Steps.ScenarioHelper
{
    [Binding]
    public  class LogInSteps
    {
        private readonly IE _browser;
        private readonly AccountManagement.Specs.Steps.PageInteraction.PageUrls _pageUrls;
        string username, password;

        public LogInSteps(IE browser)
        {
            _browser = browser;
            _pageUrls = new AccountManagement.Specs.Steps.PageInteraction.PageUrls();
        }

        [Given(@"I'm logged in.")]// with ""(.*)"" and ""(.*)""")]
        public void GivenIMLoggedIn()//string useremail, string pass)
        {
            _browser.GoTo(_pageUrls["Login"]);
            TextField nametxt = _browser.TextField(Find.ByName("UserName"));
            TextField passtxt = _browser.TextField(Find.ByName("Password"));
            Button login = _browser.Button(Find.ByName("login"));

            Assert.IsTrue(nametxt.Exists, "The Text {0} doesnt exist", "UserName");
            nametxt.TypeText(UserName);
            Assert.IsTrue(passtxt.Exists, "The Text {0} doesnt exist", "Password");
            passtxt.TypeText(password);

            Assert.AreEqual(username, nametxt.Text);
            Assert.AreEqual(password, passtxt.Text);
            Assert.IsTrue(login.Exists, "The button Add doesnt exist");
            login.Click();
            // _browser.GoTo("http://localhost:8089/AccountManagement");
        }
        public string UserName
        {
            get
            {
              if(ScenarioContext.Current.ContainsKey("username"))
                return ScenarioContext.Current["username"] as string;
              throw new System.ApplicationException("No username provided in current scenarion context");
            }
            
        }
        public string Password
        {
            get
            {
                if (ScenarioContext.Current.ContainsKey("password"))
                    return ScenarioContext.Current["password"] as string;
                throw new System.ApplicationException("No password provided in current scenarion context");
            }

        }
    }
}
