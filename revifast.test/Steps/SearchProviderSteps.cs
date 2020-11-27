using Revifast.Entities;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace revifast.test.Steps
{
    class LEmpresas
    {
        public LEmpresas()
        {
            Empresas.Add(new Empresa { EmpresaId = 100, Nombre = "Tesla", Ruc = "RM34M", Telefono = "948018312", Correo = "teslamotor@gmail" });
        }

        List<Empresa> Empresas = new List<Empresa>();

        public List<Empresa> Where(int id)
        {
            if (id == 1)
            {
                return Empresas;
            }
            else return null;
        }

    }

    class Context
    {
        public LEmpresas Empresas = new LEmpresas();
        public LReservations Reservas = new LReservations();

    }

    [Binding]
    public class SearchProviderSteps
    {
        Context _context = new Context();
        Empresa provider;
        int providerId;
        List<Empresa> empresas;

        [Given(@"the client specifies valid data to look for a provider")]
        public void GivenTheClientSpecifiesValidDataToLookForAProvider()
        {
            providerId = 1;
        }
        
        [Given(@"the client specifies invalid data to look for a provider")]
        public void GivenTheClientSpecifiesInvalidDataToLookForAProvider()
        {
            providerId = -12;
        }
        
        [When(@"the client sends this data to the system")]
        public void WhenTheClientSendsThisDataToTheSystem()
        {
            empresas = _context.Empresas.Where(id: providerId);
        }
        
        [Then(@"the system will successfuly return a list of providers")]
        public void ThenTheSystemWillSuccessfulyReturnAListOfProviders()
        {
            Assert.IsNotEmpty(empresas);
        }
        
        [Then(@"the system will return an error")]
        public void ThenTheSystemWillReturnAnError()
        {
            Assert.IsNull(empresas);
        }
    }
}
