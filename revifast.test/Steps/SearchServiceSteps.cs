using Revifast.Data;
using Revifast.Entities;
using System;
using TechTalk.SpecFlow;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FluentAssertions;

namespace revifast.test.Steps
{
    [Binding]
    public class SearchServiceSteps
    {
        private readonly DbRevifastContext _context;
        Conductor conductor;
        int providerId;
        Empresa result;

        [Given(@"the user is registered")]
        public void GivenTheUserIsRegistered()
        {
            conductor = new Conductor
            {
                Nombre = "Pepe",
                Apellido = "Luna",
                Celular = "948049393",
                Dni = "74917891",
                Correo = "pepeluna@gmail.com",
                Direccion = "Av. Los Ciclistas 202, Santiago de Surco"
            };

            _context.Add(conductor);
        }
        
        [Given(@"the user is looking for an specific service provider with valid data")]
        public void GivenTheUserIsLookingForAnSpecificServiceProviderWithValidData()
        {
            providerId = 1;
        }
        
        [Given(@"the user is looking for an specific service provider with invalid data")]
        public void GivenTheUserIsLookingForAnSpecificServiceProviderWithInvalidData()
        {
            providerId = -1;
        }
        
        [When(@"the user queries the system through the API")]
        public void WhenTheUserQueriesTheSystemThroughTheAPI()
        {
            result = _context.Empresas.FindAsync(providerId).Result;
        }
        
        [Then(@"the system will return a list of technical providers")]
        public void ThenTheSystemWillReturnAListOfTechnicalProviders()
        {
            result.Should().NotBeNull();
        }

        [Then(@"the system will return an error")]
        public void ThenTheSystemWillReturnAnError()
        {
            result.Should().BeNull();
        }

    }
}
