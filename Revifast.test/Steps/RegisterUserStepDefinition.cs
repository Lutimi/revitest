using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace revifast.test.Steps
{
    [Binding]
    public  class RegisterUserStepDefinition
    {
        public List<User> usuarios = new List<User>();
        private User usuario;
        private readonly ScenarioContext _scenarioContext;
        private readonly DataAcess _dataaccess;
        private string Email;
        private string Password;

        public RegisterUserStepDefinition(ScenarioContext scenarioContext)
        {
            usuario = new User();
            _dataaccess = new DataAcess();
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user enters an existing '(.*)' and '(.*)'")]
        [Given(@"user adds correct '(.*)' and '(.*)' to register")]
        public bool GivenUserAddsCorrectAndToRegister(string email, string password)
        {
            try
            {
                usuarios = usuario.getUsers();
                User aux = usuario.getReservabyCorreo(email);
  
                return false;

                throw new Exception("could not list your reservations friend crack");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return true;
            }

        }

        [When(@"The user clicks the register button")]
        public async Task WhenTheUserClicksTheRegisterButton_()
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

        [Then(@"the system will record the user's data in the database '(.*)' and '(.*)'\.")]
        public bool ThenTheSystemWillRecordTheUserSDataInTheDatabase_(string email, string password)
        {
            try
            {
                usuarios.Add(new User
                {
                    Nombre = "Carlos",
                    Apellido = "Sanchez",
                    Dni = "72845614",
                    Direccion = "1 Maple St, New York Mills, NY 13417, Estados Unidos",
                    Celular = "999650148",
                    Correo = email,
                    Contraseña = password,


                });

                throw new Exception("Couldn't remove element");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    

        [Then(@"The system will notify the user that it could not be registered and to correct the data\.")]
        public void ThenTheSystemWillNotifyTheUserThatItCouldNotBeRegisteredAndToCorrectTheData_()
        {
            Console.WriteLine("the account already exists");
        }

        public class User
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Dni { get; set; }
            public string Direccion { get; set; }
            public string Celular { get; set; }
            public string Correo { get; set; }
            public string Contraseña { get; set; }

            public List<User> getUsers()
            {
                List<User> examples = new List<User>();
                for (int i = 0; i < 10; i++)
                {
                    examples.Add(new User
                    {
                        Nombre = "Carlos",
                        Apellido = "Sanchez",
                        Dni = "72845614",
                        Direccion = "1 Maple St, New York Mills, NY 13417, Estados Unidos",
                        Celular = "999650148",
                        Correo = "carlosfuente45" + i.ToString(),
                        Contraseña = "12345" + i.ToString(),

                    }); ; ;
                }
                return examples;
            }

            public User getReservabyCorreo(string correo)
            {
                User example = new User();
                List<User> aux = example.getUsers();
                example = aux.Find(x => x.Correo == correo);
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
