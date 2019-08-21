using Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Core
{
    public interface IClientService
    {
        Task<ClientDTO> AddClient(ClientDTO client);
        Task<List<ClientDTO>> GetClients();
    }
}
