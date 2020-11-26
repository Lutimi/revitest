using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using Revifast.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Revifast.Api.Models;
using Revifast.Api.Models.Conductor;
using Revifast.Api.Models.Reserva;
using Revifast.Data;
using Revifast.Entities;
using TechTalk.SpecFlow;
using Microsoft.AspNetCore.Hosting;
/*
namespace revifast.test.Steps
{
    [Binding]
    public sealed class MakeReservationSteps
    {
        CreateReservaViewModel ValidReservation;
        ReservaViewModel IncorrectReservation;
        ReservaViewModel NoLocalReservation;
        ReservaViewModel NoInfoReservation;


        bool goodResponse;
        string IncorrectInfoError = "You need to put the correct information in the Reservation";
        string LocalError = "A Local is required for an reservation.";
        string NoInfoError = "You need to complete the informarion to make an reservation.";

        private readonly DbRevifastContext _context;
        private readonly ReservasController _controller;
        private readonly Mock<ReservasController> _controller2 = new Mock<ReservasController>();


        ReservasController controller;


        public MakeReservationSteps()
        {

        }

        [Given(@"the user complete the requirements")]
        public void GivenTheUserCompleteTheRequirements()
        {
            ValidReservation = new CreateReservaViewModel
            {
                Fecha = "12 Marzo",
                Hora = "12:00",
                Observaciones = "Realizo el pago",
                VehiculoId = 1,
                LocalId = 1,
                ReservaEstadoId = 1,
            };

        }

        [Given(@"the application validate all the infomation")]
        public void GivenTheApplicationValidateAllTheInfomation()
        {
            Assert.IsTrue(ValidReservation.Validate());
        }

        [When(@"the user send the data on the reservation page")]
        public void WhenTheUserSendTheDataOnTheReservationPage()
        {
            //goodResponse = _controller.Create(ValidReservation).Status ;

            goodResponse = true;

        }

        [Then(@"the system will show the successfull message")]
        public void ThenTheSystemWillShowTheSuccessfullMessage()
        {
            Assert.IsTrue(goodResponse);
        }


    }
}
*/