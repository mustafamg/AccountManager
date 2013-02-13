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
namespace AccountManagement.Specs.Steps
{
    [Binding]
    public class AccountDataManagementSteps
    {
        private readonly IE _browser;
        string username, password;

        public AccountDataManagementSteps(IE browser)
        {
            _browser = browser;
        }

        /// <summary>
        /// /step 1 
        /// </summary>
        /// <param name="p0"></param>
        [Given(@"I am on ""(.*)"" page")]
        public void GivenIAmOnPage(string p0)
        {
            //goto home page
            _browser.GoTo("http://localhost:8089/");
        }
        /// <summary>
        /// /step 2
        /// </summary>
        /// <param name="table"></param>
        [Given(@"I am registered with the following data:")]
        public void GivenIAmRegisteredWithTheFollowingData(TechTalk.SpecFlow.Table table)
        {
            var tableSerialized = new SerializableTable(table);
            username = tableSerialized.Rows[0]["email"];
            password = tableSerialized.Rows[0]["password"];
            //mobile = tableSerialized.Rows[0]["mobile"];
            //gender = tableSerialized.Rows[0]["gender"];

            Deleporter.Run(() =>
            {
                var mockRepository = new Mock<IRegisterRepository>();
                mockRepository.Setup(x => x.Get(tableSerialized.Rows[0]["email"]))
                    .Returns((from row in tableSerialized.Rows
                              select new RegisterEntry
                              {
                                  Name = tableSerialized.Rows[0]["name"],
                                  Password = tableSerialized.Rows[0]["password"],
                                  Email = tableSerialized.Rows[0]["email"],
                                  Mobile = tableSerialized.Rows[0]["mobile"],
                                  Gender = Convert.ToChar(tableSerialized.Rows[0]["gender"][0]),
                                  Activated = tableSerialized.Rows[0]["activated"] == "yes" ? true : false
                              }).ToList()[0]);
                NinjectControllerFactoryUtils.TemporarilyReplaceBinding<IRegisterRepository>(mockRepository.Object);
            });
            //ScenarioContext.Current.Pending();
        }
        /// <summary>
        /// /step3
        /// </summary>
        /// <param name="useremail"></param>
        /// <param name="pass"></param>
        [Given(@"I'm logged in")]// with ""(.*)"" and ""(.*)""")]
        public void GivenIMLoggedIn()//string useremail, string pass)
        {
            _browser.GoTo("http://localhost:8089/account/login");
            TextField nametxt = _browser.TextField(Find.ByName("UserName"));
            TextField passtxt = _browser.TextField(Find.ByName("Password"));
            Button login = _browser.Button(Find.ByName("login"));

            Assert.IsTrue(nametxt.Exists, "The Text {0} doesnt exist", "UserName");
            nametxt.TypeText(username);
            Assert.IsTrue(passtxt.Exists, "The Text {0} doesnt exist", "Password");
            passtxt.TypeText(password);

            Assert.AreEqual(username, nametxt.Text);
            Assert.AreEqual(password, passtxt.Text);
            Assert.IsTrue(login.Exists, "The button Add doesnt exist");
            login.Click();
        }
        /// <summary>
        /// /step 4
        /// </summary>
        /// <param name="buttonLabel"></param>

        [When(@"I click on ""(.*)"" link")]
        public void WhenIClickOnLink(string linkId)
        {
            ////create             
            Link login = _browser.Link(Find.ById(linkId));
            Assert.IsTrue(login.Exists, "The Link {0} doesnt exist", linkId);
            login.Click();
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
            //RegisterEntry entry = new RegisterEntry();
            foreach (var header in table.Header)
            {
                Assert.AreEqual(_browser.Element(header).Text, table.Rows[0][header]);
            }
            //Assert.AreEqual(_browser.Element("name").Text, table.Rows[0]["name"]);
            //Assert.AreEqual(_browser.Element("email").Text, table.Rows[0]["email"]);
            //Assert.AreEqual(_browser.Element("gender").Text, table.Rows[0]["gender"]);
            //Assert.AreEqual(_browser.Element("mobile").Text, table.Rows[0]["mobile"]); 
        }

        /// <summary>
        /// /step 2.2 view editable data 
        /// </summary>
        /// <param name="table"></param>
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
        /// <summary>
        /// step 2.3 enter updated data
        /// </summary>
        /// <param name="table"></param>
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
        /// <param name="msg"></param>
        [Then(@"I should see ""(.*)"" message")]
        public void ThenIShouldSeeMessage(string msg)
        {
            _browser.ContainsText(msg);
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
