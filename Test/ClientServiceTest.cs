using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Repositories.Core;
using Repositories.Entities;
using Services.Core;
using Services.DTO;
using Services.Impl;
using System;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ClientServiceTest
    {
        private IClientRepository _ClientRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _ClientRepository = Substitute.For<IClientRepository>();
            Client client = new Client() { Name = "Harvin", Address = "CL 33C No 88A 115" };
            _ClientRepository
                .AddClient(Arg.Any<Client>())
                .Returns(Task.FromResult(client));

        }


        [TestMethod]
        public  void AddClientAsyncTest_Expected()
        {
            
            ClientDTO clientDTO = new ClientDTO() { Name = "Harvin", Address = "CL 33C No 88A 115" };

            IClientService service = new ClientService(_ClientRepository);

            var task =  service.AddClient(clientDTO);
            task.Wait();
            var result = task.Result;

            Assert.IsTrue(result is ClientDTO, "Error haba");
        }

        [TestMethod]
        public void AddClientAsyncTest_NO_data_Excewption()
        {
            ClientDTO clientDTO = new ClientDTO() { };

            IClientService service = new ClientService(_ClientRepository);

            try
            {
                var task = service.AddClient(clientDTO);
                task.Wait();
                var result = task.Result;
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is Exception);
            }
            

        }
    }
}
