using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace revifast.test.Steps
{
    [Binding]
    public  class DeleteReservationStepDefinition
    {
        public  List<Reserva> reservas = new List<Reserva>();
        private bool userAgrement;
        private  Reserva example;
        private readonly ScenarioContext _scenarioContext;
        private readonly DataAcess _dataaccess;

        public DeleteReservationStepDefinition(ScenarioContext scenarioContext)
        {
            example = new Reserva();
            _dataaccess = new DataAcess();
            _scenarioContext = scenarioContext;
        }


        [Given(@"the user agree to '(.*)' a reservation")]
        public bool UserAgreement(string cancelAgree)
        {
            try
            {
                if (cancelAgree == "Cancel")
                {
                    userAgrement = true;
                    return userAgrement;
                }
                else
                {
                    throw new Exception("User didn't agree to cancel a reservation");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        [Given(@"the user does '(.*)' to cancel a reservation")]
        public bool UserDisagreement(string agreement)
        {
            try
            {
                if (agreement == "not agree")
                {
                    userAgrement = true;
                    return userAgrement;
                }
                else
                {
                    throw new Exception("User didn't agree to cancel a reservation");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        [When(@"the user clicks the delete button")]
        [When(@"the user tries to delete a reservation")]
        public async Task onclickButton()
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

        

        [Then(@"the reservation with id '(.*)' should be deleted")]
        public bool DeleteReservation(int idReservation)
        {
            //mandar la solicitud de 
            try
            {
                    reservas = example.getReservas();
                    Reserva aux = example.getReservabyId(idReservation);
                    return reservas.Remove(aux);

                throw new Exception("Couldn't remove element");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        [Then(@"an alert should notify the reservation is still in process")]
        public void DeleteReservation2()
        {
            Console.WriteLine("Reservation is still in process");
        }
    }

    public class Reserva
    {
        // ID
        public int ReservaId { get; set; }
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
                    Fecha = "22/03/00",
                    Hora = "12:00",
                    Estado = "activo"

                });
            }
            return examples;
        }

        public Reserva getReservabyId(int id)
        {
            Reserva example = new Reserva();
            List<Reserva> aux= example.getReservas();
            example= aux.Find(x=>x.ReservaId==id);
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
