using AssistWith.Data;
using AssistWith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssistWith.Services
{
    public interface IClientService
    {
        void Delete(Client client);
        IQueryable<Client> GetAll();
        Client GetById(int ClientId);
        void Insert(Client client);
        void Update(Client client);
    }
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IEncryptionService _encryptionService;
        public ClientService()
        {
        }
        public ClientService(
            IRepository<Client> clientRepository
            , IEncryptionService EncryptionService)
        {
            _clientRepository = clientRepository;
            _encryptionService = EncryptionService;
        }
        public virtual Client GetById(int ClientId)
        {
            Client client = _clientRepository.GetById(ClientId);
            return client;
        }
        public virtual IQueryable<Client> GetAll()
        {
            IQueryable<Client> clients = _clientRepository.Table;
            return clients;
        }
        public virtual void Insert(Client client)
        {
            if (client == null)
                throw new ArgumentNullException("Client");
            client.PasswordSalt = _encryptionService.CreateSalt(24);
            _clientRepository.Insert(client);
        }
        public virtual void Update(Client client)
        {
            if (client == null)
                throw new ArgumentNullException("Client");
            _clientRepository.Update(client);
        }
        public virtual void Delete(Client client)
        {
            if (client == null)
                throw new ArgumentNullException("Client");
            _clientRepository.Delete(client);
        }
    }
}