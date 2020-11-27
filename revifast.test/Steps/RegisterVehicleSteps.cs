using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace revifast.test.Steps
{
    [Binding]
    public class RegisterVehicleSteps
    {
        private Vehicle vehiculo;
        private Table vehiculo2;
        private readonly DataAcess dataAcess = new DataAcess();

        [Given(@"a user types '(.*)'")]
        public void GivenAUserTypes(string p0)
        {
            //imprimir informacion inicial
            Console.WriteLine(p0);
        }
        
        [Given(@"a user do not type '(.*)'")]
        public void GivenAUserDonHisInfo(string p0)
        {
            Console.WriteLine(p0);
        }
        
        [When(@"register in the app")]
        public async Task WhenRegisterInTheAppAsync(Table table)
        {
            //compara la tabla con un objeto
            vehiculo = new Vehicle();
            //vehiculo2 = table.CreateInstance<Vehicle>();
            await dataAcess.Sync();
        }
        
        [Then(@"our app will '(.*)' the register to the user")]
        public void ThenOurAppWillTheRegisterToTheUser(string p0)
        {
            try
            {
                if (vehiculo != null)
                {
                    vehiculo2.CompareToInstance<Vehicle>(vehiculo);
                    Console.WriteLine("Vehiculo creado correctamente", p0);
                }
                else
                {
                    throw new Exception("Vehiculo no se ha podido crear");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        [Then(@"our app will '(.*)' the user")]
        public void ThenOurAppWillWarnTheUser(string ip)
        {
            try
            {
                if (vehiculo != null)
                {
                    vehiculo2.CompareToInstance<Vehicle>(vehiculo);
                    Console.WriteLine("Vehiculo creado correctamente");
                }
                else
                {
                    throw new Exception("Vehiculo no se ha podido crear");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        [Then(@"our app will send an '(.*)' to the user")]
        public void ThenOurAppWillSendAnErrorToTheUser(string p0)
        {
            try
            {
                if (vehiculo != null)
                {
                    vehiculo2.CompareToInstance<Vehicle>(vehiculo);
                    Console.WriteLine("Vehiculo creado correctamente", p0);
                }
                else
                {
                    throw new Exception("Vehiculo no se ha podido crear");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, p0);
            }
        }

        private class Vehicle
        {
            public int id { get; set; } = 1;
            public string placa { get; set; } = "DEV123";
            public string color { get; set; } = "azul";
            public string fecha {get; set; } = "12-09-20";



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
