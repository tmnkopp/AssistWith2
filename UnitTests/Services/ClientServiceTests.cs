using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssistWith.Services;
using System;
using System.Collections.Generic;
using System.Text;
using AssistWith.Models;
using AssistWith.Data;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace AssistWith.Services.Tests
{
    [TestClass()]
    public class ClientServiceTests
    {
        [TestMethod()]
        public void ClientInserts()
        {

          // Mock<ApplicationDbContext> mockDb = new Mock<ApplicationDbContext>();
          // Mock<EfRepository<Client>> mockRepo = new Mock<EfRepository<Client>>(mockDb.Object);
          //
          // var data = new List<Client>()
          // {
          //     new Client { ClientID=1 },
          //     new Client { ClientID=2 },
          //     new Client { ClientID=3 }
          // }.AsQueryable();
          //
          // var expectedResults = data.Where(m => m.ClientID == 1);
          //  
          // var mockSetc = new Mock<IQueryable<Client>>();
          // mockSetc.As<IQueryable<Client>>();
          //   
          // mockRepo.Setup(m => m.Table)
          //     .Returns( mockSetc.Object );
          //
          // EncryptionService _encryptionService = new EncryptionService();
          // ClientService clientService = new ClientService(); 
          // Client client = new Client();
          // client.Company = "Delete";
          // client.PasswordSalt = _encryptionService.CreateSalt(24);
          // clientService.Insert(client);
          //
          // Assert.Fail();
        } 
    }
}