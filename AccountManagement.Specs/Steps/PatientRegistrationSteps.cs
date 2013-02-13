using System;
using TechTalk.SpecFlow;

namespace AccountManagement.Specs.Steps
{
    [Binding]
    public class PatientRegistrationSteps
    {
        [Then(@"I should receive activation email\.")]
        public void ThenIShouldReceiveActivationEmail_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
