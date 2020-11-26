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
            Console.WriteLine("correctus");
        }

        [Given(@"the user want to validate his reservation information")]
        public void GivenTheUserWantToValidateHisReservationInformation()
        {
            Console.WriteLine("correctus");
        }

        [When(@"the user click on the reservation information icon")]
        public void WhenTheUserClickOnTheReservationInformationIcon()
        {
            Console.WriteLine("correctus");
        }

        [Then(@"the system will show the reservation information")]
        public void ThenTheSystemWillShowTheReservationInformation()
        {
            Console.WriteLine("correctus");
        }

    }
}
