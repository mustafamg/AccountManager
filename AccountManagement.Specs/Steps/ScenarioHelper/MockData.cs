using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Specs.Infrastructure;
using TechTalk.SpecFlow;
using WatiN.Core;
using Moq;
using DeleporterCore.Client;
using AccountManagement.Models;

namespace AccountManagement.Specs.Steps.ScenarioHelper
{
    [Binding]
    public  class MockData
    {
      private readonly IE _browser;
      public MockData(IE browser)
      {
          _browser = browser;
       //   ScenarioContext.Current["username"]= username;
      }
      [Given(@"I am registered with the following data:")]
      public void GivenIAmRegisteredWithTheFollowingData(TechTalk.SpecFlow.Table table)
      {
          var tableSerialized = new SerializableTable(table);
          ScenarioContext.Current["username"] = tableSerialized.Rows[0]["email"];
          ScenarioContext.Current["password"] = tableSerialized.Rows[0]["password"];
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
    }
}
