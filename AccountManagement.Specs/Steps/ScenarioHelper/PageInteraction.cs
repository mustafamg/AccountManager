using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using AccountManagement.Specs.steps;
using AccountManagement.Models;
using AccountManagement.Specs.Infrastructure;
using Moq;
using TechTalk.SpecFlow;
using WatiN.Core;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeleporterCore.Client;


namespace AccountManagement.Specs.Steps
{
    [Binding]
    public class PageInteraction
    {
        private readonly IE _browser;
        private readonly PageUrls _pageUrls;
        string username, password;


        public PageInteraction(IE browser)
        {
            _browser = browser;
            _pageUrls = new PageUrls();

            ScenarioContext.Current["username"] = username;
            ScenarioContext.Current["password"] = password;
        
        }
        [When(@"I press on ""(.*)""")]
        public void WhenIPressOn(string buttonLabel)
        {
            Button btn = _browser.Button(Find.ByName(buttonLabel));
            Assert.IsTrue(btn.Exists, "The button {0} doesnt exist", buttonLabel);
            btn.Click();

        }

        [When(@"I click on ""(.*)"" link")]
        public void WhenIClickOnLink(string linkId)
        {          
            Link link = _browser.Link(Find.ById(linkId));
            Assert.IsTrue(link.Exists, "The Link {0} doesnt exist", linkId);
            link.Click();
        }

        
        // step 1.1 view data 
       
        [Then(@"I should see the following data:")]
        public void ThenIShouldSeeTheFollowingData(TechTalk.SpecFlow.Table table)
        {
            foreach (var header in table.Header)
            {
                Assert.AreEqual(_browser.Element(header).Text, table.Rows[0][header]);
            }
        }

        

        [When(@"I update the following data:")]
        public void WhenIUpdateTheFollowingData(TechTalk.SpecFlow.Table table)
        {

            TextField nametxt = _browser.TextField(Find.ByName("Name"));
            Assert.IsTrue(nametxt.Exists, "The Text {0} doesnt exist", "Name");
            nametxt.TypeText(table.Rows[0][0]);

            TextField gendertxt = _browser.TextField(Find.ByName("Gender"));
            Assert.IsTrue(gendertxt.Exists, "The Text {0} doesnt exist", "Gender");
            gendertxt.TypeText(table.Rows[0][1]);

            TextField mobiletxt = _browser.TextField(Find.ByName("Mobile"));
            Assert.IsTrue(mobiletxt.Exists, "The Text {0} doesnt exist", "Mobile");
            mobiletxt.TypeText(table.Rows[0][2]);

            Button btn = _browser.Button(Find.ByName("Save"));
            Assert.IsTrue(btn.Exists, "The button Add doesnt exist");
            btn.Click();
        }

        //step 2.2 view editable data 
      
        [Then(@"I should see the following data editable:")]
        public void ThenIShouldSeeTheFollowingDataEditable(TechTalk.SpecFlow.Table table)
        {
            foreach (var header in table.Header)
            {
                Assert.AreEqual(_browser.Element(header.ToUpperInvariant()).Text, table.Rows[0][header]);
            }
            Assert.AreEqual(_browser.Element("name").TagName, "input");
            Assert.AreEqual(_browser.Element("email").TagName, "input");
            Assert.AreEqual(_browser.Element("gender").TagName, "input");
            Assert.AreEqual(_browser.Element("mobile").TagName, "input");
        }
       

        // step 2.4 successful message
       
        /// <param name="message"></param>
        [Then(@"I should see ""(.*)"" message.")]
        public void ThenIShouldSeeMessage(string message)
        {
            _browser.ContainsText(message);
        }

        [Then(@"I should see ""(.*)"" message ""(.*)""")]
        public void ThenIShouldSeeMessage(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see ""(.*)"" form")]
        public void ThenIShouldSeeForm(string formId)
        {
            Form form = _browser.Form(Find.ById(formId));
            Assert.IsTrue(form.Exists, "The Link {0} doesnt exist", formId);
            
        }

        //Todo: Ask team about adding this feature to dictionary
        [Given(@"I have filled out the form as follows")]
        public void GivenIHaveFilledOutTheFormAsFollows(TechTalk.SpecFlow.Table table)
        {
            foreach (var row in table.Rows)
            {
                var labelText = row["Label"] + ":";
                var value = row["Value"];
                _browser.TextFields.First(Find.ByLabelText(labelText)).TypeText(value);
            }
        }

       
        // 2.5 see the result of update 
      
        [Then(@"I should see the updated data:")]
        public void ThenIShouldSeeTheUpdatedData(TechTalk.SpecFlow.Table table)
        {
            ScenarioContext.Current.Pending();
        }
  
        
        
        
        
        public class PageUrls
        {
            public Dictionary<string, string> Pages = new Dictionary<string, string>();
            public Uri BaseUrl;
            public PageUrls()
            {
                // BaseUrl = new Uri(ConfigurationManager.AppSettings["BaseUri"]);

                Pages.Add("home", "/");
            }
            public Uri this[string key]
            {
                get
                {
                    return new Uri(BaseUrl, Pages[key.ToLower()]);
                }

            }

        }
    }
}
