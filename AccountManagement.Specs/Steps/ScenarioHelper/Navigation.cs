using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TechTalk.SpecFlow;
using WatiN.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AccountManagement.Specs.Steps.ScenarioHelper
{
    [Binding]
    public class Navigation
    {
        private readonly IE _browser;
        private readonly PageUrls _pageUrls;
        
        public Navigation(IE browser)
        {
            _browser = browser;
            _pageUrls = new PageUrls();
        }

        [Given(@"I am on ""(.*)"" page.")]
        public void GivenIAmOnPage(string pageTitle)
        {
            _browser.GoTo(_pageUrls[pageTitle]);
            Assert.AreEqual(pageTitle,_browser.Title,"Page Title doesnt exist");
        }

        //Todo: Ask team about adding this feature to dictionary
        [When(@"I navigate to (.*)")]
        public void WhenINavigateTo(string pageTitle)
        {
            GivenIAmOnPage(pageTitle);
        }

        //[Then(@"I should be on the guestbook page")]
        //public void ThenIShouldBeOnTheGuestbookPage()
        //{
        //    Assert.AreEqual(_browser.Title, "AccountManagement");
        //}

        //[Given(@"I am on the guestbook page")]
        //public void GivenIAmOnTheGuestbookPage()
        //{
        //    WhenINavigateTo(_navs["accountmanagement"]);
        //}

        //[Then(@"I am on the posting page")]
        //public void ThenIAmOnThePostingPage()
        //{
        //    Assert.AreEqual(_browser.Title, "AccountManagement : Post a New Entry");
        //}

        //[Given(@"I am on the posting page")]
        //public void GivenIAmOnThePostingPage()
        //{
        //    GivenIAmOnTheGuestbookPage();
        //    WhenIClickTheButtonLabelled("Post a New Entry");
        //}

        //[Then(@"I should see a button labelled ""(.*)""")]
        //public void ThenIShouldSeeAButtonLabelled(string label)
        //{
        //    var matchingButtons = _browser.Buttons.Filter(Find.ByText(label));
        //    Assert.AreEqual(matchingButtons.Count, 1);
        //}

        //[When(@"I click the button labelled ""(.*)""")]
        //public void WhenIClickTheButtonLabelled(string label)
        //{
        //    _browser.Buttons.First(Find.ByText(label)).Click();
        //}

        //[Then(@"I see the flash message ""(.*)""")]
        //public void ThenISeeTheFlashMessage(string message)
        //{
        //    var flashElement = _browser.Element("flashMessage");
        //    Assert.AreEqual(flashElement.Text, message);
        //}

        //[Then(@"I should see a field labelled ""(.*)""")]
        //public void ThenIShouldSeeAFieldLabelled(string label)
        //{
        //    var matchingFields = _browser.TextFields.Filter(Find.ByLabelText(label + ":"));
        //    Assert.AreEqual(matchingFields.Count, 1);
        //}

        //[Given(@"I have filled out the form as follows")]
        //public void GivenIHaveFilledOutTheFormAsFollows(TechTalk.SpecFlow.Table table)
        //{
        //    foreach (var row in table.Rows)
        //    {
        //        var labelText = row["Label"] + ":";
        //        var value = row["Value"];
        //        _browser.TextFields.First(Find.ByLabelText(labelText)).TypeText(value);
        //    }
        //}


        public class PageUrls
        {
            public Dictionary<string, string> Pages = new Dictionary<string, string>();
            public Uri BaseUrl;
            public PageUrls()
            {
                BaseUrl = new Uri(ConfigurationManager.AppSettings["BaseUri"]);
                Pages.Add("home", "/");
                Pages.Add("Login", "login/");
            }
            public Uri this[string pageTitle]
            {
                get
                {
                    return new Uri(BaseUrl,Pages[pageTitle.ToLower()]);
                }

            }

        }

    }
}
