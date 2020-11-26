using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace revifast.test.Steps
{
    [Binding]
    public sealed class reservationdetailsstatus
    {
        [When(@"see the following details")]
        public void WhenSeeTheFollowingDetails(Table table)
        {
            Console.WriteLine("Correct");
        }

        [When(@"click on view reservation")]
        public void WhenClickOnViewReservation()
        {
            Console.WriteLine("Correct");
        }

        [Then(@"the system will show the reservation and it status")]
        public void ThenTheSystemWillShowTheReservationAndItStatus()
        {
            Console.WriteLine("Correct");
        }

    }
}
