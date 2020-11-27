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
using System.Threading.Tasks;

namespace revifast.test.Steps
{
    [Binding]
    public sealed class MakeReservationSteps
    {
        CreateReservaViewModel ValidReservation;
        ReservaViewModel IncorrectReservation;
        ReservaViewModel NoLocalReservation;
        ReservaViewModel NoInfoReservation;
        ReservaViewModel example;

        bool goodResponse;
        bool badResponse;
        string IncorrectInfoError = "You need to put the correct information in the Reservation";
        string LocalError = "A Local is required for an reservation.";
        string NoInfoError = "You need to complete the informarion to make an reservation.";

        private readonly DbRevifastContext _context;
        private readonly ReservasController _controller;
        private readonly DataAcess _dataaccess;

        ReservasController controller;


        public MakeReservationSteps()
        {

            //_controller2.Setup(or => or.Create(ValidReservation)).Returns(new Task(action: new Action(() => new ReservaMap(ValidReservation))));
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
            goodResponse = ValidReservation.Validate();
        }

        [When(@"the user send the data on the reservation page")]
        public async Task WhenTheUserSendTheDataOnTheReservationPage()
        {
            //goodResponse = _controller.Create(ValidReservation).Status ;
            /*_controller.Create(ValidReservation).Result
            if(_controller.Create(ValidReservation).Result == _controller.Ok) */

            try
            {
                await _dataaccess.Sync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Then(@"the system will show the successfull message")]
        public void ThenTheSystemWillShowTheSuccessfullMessage()
        {
            Assert.IsTrue(goodResponse);
        }


        public class DataAcess
        {
            public Task Sync()
            {

                return Task.CompletedTask;
            }
        }

        [Given(@"the user complete the requirements with an incorrect data")]
        public void GivenTheUserCompleteTheRequirementsWithAnIncorrectData()
        {
            IncorrectReservation = new ReservaViewModel
            {
                Fecha = "12 Marzo",
                Hora = "12:00",
                Observaciones = "Realizo el pago",
                Vehiculo = "XYZ123",
                Local = "Av. La molina",
                Estado = "En proceso",
            };
        }

        [Given(@"the application verify all the infomation")]
        public void GivenTheApplicationVerifyAllTheInfomation()
        {

            
            Assert.IsFalse(IncorrectReservation.Verify());

        }

        [Then(@"the system will show an Error message")]
        public void ThenTheSystemWillShowAnErrorMessage()
        {
            Console.WriteLine(IncorrectInfoError);
        }

        [Given(@"the user didnt complete the information, don't specify the local")]
        public void GivenTheUserDidntCompleteTheInformationDonTSpecifyTheLocal()
        {
           
        NoLocalReservation = new ReservaViewModel
            {
                Fecha = "12 Marzo",
                Hora = "12:00",
                Observaciones = "Realizo el pago",
                Vehiculo = "ABC123",
                Estado = "En proceso",
            };
        }

        [Given(@"the application check if everything is ok")]
        public void GivenTheApplicationCheckIfEverythingIsOk()
        {
            Assert.IsFalse(NoLocalReservation.Validate());
        }

        [Then(@"the system will show an Local Error message")]
        public void ThenTheSystemWillShowAnLocalErrorMessage()
        {
            Console.WriteLine(LocalError);

        }

        [Given(@"the user didnt complete the information")]
        public void GivenTheUserDidntCompleteTheInformation()
        {
            NoInfoReservation = new ReservaViewModel
            {
                Observaciones = "Realizo el pago",
                Vehiculo = "ABC123",
                Estado = "En proceso",
            };
        }

        [Given(@"the application check if something if missing")]
        public void GivenTheApplicationCheckIfSomethingIfMissing()
        {
            Assert.IsFalse(NoInfoReservation.Validate());
        }

        [Then(@"the system will show an Info Error message")]
        public void ThenTheSystemWillShowAnInfoErrorMessage()
        {
            Console.WriteLine(NoInfoError);
        }


       



    }
}