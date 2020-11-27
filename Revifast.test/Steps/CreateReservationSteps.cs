using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;


namespace revifast.test.Steps
{
    class LReservations
    {
        public LReservations()
        {
        }

        List<Reserva> Reservas = new List<Reserva>();


        public void Add (Reserva r)
        {
            Reservas.Add(r);
        }

        public List<Reserva>  GetAll()
        {
            return Reservas;
        }

    }

    [Binding]
    public class CreateReservationSteps
    {
        Context _context = new Context();
        Reserva reservation;
        int providerId;
        List<Reserva> reservations;

        [Given(@"the client specifies valid data for a reservation")]
        public void GivenTheClientSpecifiesValidDataForAReservation()
        {
            reservation = new Reserva { ReservaId = 100, Fecha = "29/09/1999", Hora = "13:00GMT-5", Observaciones = "Mmmm" };
        }
        
        [Given(@"the client specifies invalid data for a reservation")]
        public void GivenTheClientSpecifiesInvalidDataForAReservation()
        {
            reservation = new Reserva { ReservaId = -1400, Fecha = "29/09/1999", Hora = "13:00GMT-5", Observaciones = "Mmmm" };
        }

        [When(@"the client sends this reservation data to the system")]
        public void WhenTheClientSendsThisReservationDataToTheSystem()
        {
            _context.Reservas.Add(reservation);
        }
        
        [Then(@"the system will successfuly save the reservation")]
        public void ThenTheSystemWillSuccessfulySaveTheReservation()
        {
            Assert.IsNotEmpty(_context.Reservas.GetAll());
        }
        
        [Then(@"the system will not save the reservation")]
        public void ThenTheSystemWillNotSaveTheReservation()
        {
            Assert.IsNotEmpty(_context.Reservas.GetAll());
        }
    }
}
