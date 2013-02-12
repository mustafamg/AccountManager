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
        string username, password;

       
        public PageInteraction()
        {

            ScenarioContext.Current["username"] = username;
            ScenarioContext.Current["password"] = password;
        
        }
        [When(@"I press on ""(.*)""")]
        public void WhenIPressOn(string buttonLabel)
        {
            ////create button
            Button btn = _browser.Button(Find.ByName(buttonLabel));
            Assert.IsTrue(btn.Exists, "The button {0} doesnt exist", buttonLabel);
            btn.Click();

        }

        /// <summary>
        /// step 1.1 view data 
        /// </summary>
        /// <param name="table"></param>
        [Then(@"I should see the following data:")]
        public void ThenIShouldSeeTheFollowingData(TechTalk.SpecFlow.Table table)
        {
            foreach (var header in table.Header)
            {
                Assert.AreEqual(_browser.Element(header).Text, table.Rows[0][header]);
            }
        }

        /// <summary>
        /// /step 2.2 view editable data 
        /// </summary>
        /// <param name="table"></param>
        [Then(@"I should see the following data editable:")]
        public void ThenIShouldSeeTheFollowingDataEditable(TechTalk.SpecFlow.Table table)
        {
            ///the edtitable data apper by defualt 
            //ScenarioContext.Current.Pending();
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

        /// <summary>
        /// step 2.4 successful message
        /// </summary>
        /// <param name="p0"></param>
        [Then(@"I should see ""(.*)"" message")]
        public void ThenIShouldSeeMessage(string p0)
        {
            _browser.ContainsText(p0);
        }

        /// <summary>
        /// 2.5 see the result of update 
        /// </summary>
        /// <param name="table"></param>
        [Then(@"I should see the updated data:")]
        public void ThenIShouldSeeTheUpdatedData(TechTalk.SpecFlow.Table table)
        {
            ScenarioContext.Current.Pending();
        }
     
    }
}
