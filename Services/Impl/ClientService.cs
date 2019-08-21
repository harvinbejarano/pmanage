using AutoMapper;
using Repositories.Core;
using Repositories.Entities;
using Services.Config;
using Services.Core;
using Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Services.Impl
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository _ClientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository ClientRepository)
        {
            _ClientRepository = ClientRepository;
            _mapper = AutoMapperConfig.Configure();
        }

        public async Task<ClientDTO> AddClient(ClientDTO client)
        {
            if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Address)) throw new Exception("Datos incompletos");

            Client entity = _mapper.Map<Client>(client);
            entity = await _ClientRepository.AddClient(entity);

            return _mapper.Map<ClientDTO>(entity);
        }

        public async Task<List<ClientDTO>> GetClients()
        {
            var list = await _ClientRepository.GetClients();
            return list.Select(data => _mapper.Map<ClientDTO>(data)).ToList();
        }
    }
}
