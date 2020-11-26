using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace revifast.test.Steps
{
    [Binding]
    public class ViewReservationHistoryStepDefinition

    {
        public List<Reserva> reservas = new List<Reserva>();
        private Reserva example;
        private readonly ScenarioContext _scenarioContext;
        private readonly DataAcess _dataaccess;
        public ViewReservationHistoryStepDefinition(ScenarioContext scenarioContext)
        {
            example = new Reserva();
            _dataaccess = new DataAcess();
            _scenarioContext = scenarioContext;
        }
        [Given(@"the user agrees to '(.*)' their reservations")]
        public bool GivenTheUserAgreesToTheirReservations(string listresult)
        {
            try
            {
                bool result = true;
                if (listresult == "list")
                {
                
                    return result;
                }
                else
                {
                    throw new Exception("a crack problem occurred");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        
        
        [When(@"the user clicks the button list reservations")]
        public async Task WhenTheUserClicksTheButtonListReservations()
        {
            try
            {
                await _dataaccess.Sync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Then(@"reservations with id '(.*)' must be list")]
        public bool ThenReservationsWithIdMustBeList(int usuario)
        {

            try
            {
                reservas = example.getReservas();
                Reserva aux = example.getReservabyIdUsuario(usuario);
                return reservas.Remove(aux);

                throw new Exception("could not list your reservations friend crack");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
           
        }

        [Given(@"the user has no reservations to list from his '(.*)'")]
        public bool GivenTheUserHasNoReservationsToListFromHis(string listnoresult)
        {
            try
            {
                bool result = false;
                if (listnoresult == "nolist")
                {

                    return result;
                }
                else
                {
                    throw new Exception("a crack problem occurred");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        [When(@"the user tries to list their reservations with their '(.*)'")]
        public bool WhenTheUserTriesToListTheirReservationsWithTheirId(int id)
        {
            try
            {
                reservas = example.getReservas();
                Reserva aux = example.getReservabyIdUsuario(id);
                return reservas.Remove(aux);

                throw new Exception("could not list your reservations friend crack");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        [Then(@"the system notifies that there is no record of reservations\.")]
        public void ThenTheSystemNotifiesThatThereIsNoRecordOfReservations_()
        {
            
            Console.WriteLine("It has nothing to list crack that makes you think that if you don't have anything to list something will magically appear just because you clicked on this function very bad crack");
        }

        public class Reserva
        {
            // ID
            public int ReservaId { get; set; }

            public int UsuarioId { get; set; }
            // FECHA
            public string Fecha { get; set; }
            // HORA ATENCION
            public string Hora { get; set; }
            // OBSERVACIONES
            public string Observaciones { get; set; }
            // ---------- HAS ONE
            //VEHICULO (CONDUCTOR)
            public string Vehiculo { get; set; }
            //LOCAL (EMPRESA)
            public string Local { get; set; }
            //PAGO ADELANTADO
            public decimal PaAdPorcentaje { get; set; }
            //RESERVA ESTADO
            public string Estado { get; set; }

            public List<Reserva> getReservas()
            {
                List<Reserva> examples = new List<Reserva>();
                for (int i = 0; i < 10; i++)
                {
                    examples.Add(new Reserva
                    {
                        ReservaId = i,
                        UsuarioId = i,
                        Fecha = "22/03/00",
                        Hora = "12:00",
                        Estado = "activo"

                    });
                }
                return examples;
            }

            public Reserva getReservabyIdUsuario(int id)
            {
                Reserva example = new Reserva();
                List<Reserva> aux = example.getReservas();
                example = aux.Find(x => x.ReservaId == id);
                return example;
            }
        }


        public class DataAcess
        {
            public Task Sync()
            {

                return Task.CompletedTask;
            }
        }


    }
}
