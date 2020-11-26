using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace revifast.test.Steps
{
    [Binding]
    public sealed class reservationdetails
    {
        [Given(@"a verfied user")]
        public void GivenAVerfiedUser()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the user want to validate his reservation information")]
        public void GivenTheUserWantToValidateHisReservationInformation()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the user click on the reservation information icon")]
        public void WhenTheUserClickOnTheReservationInformationIcon()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the system will show the reservation information")]
        public void ThenTheSystemWillShowTheReservationInformation()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
