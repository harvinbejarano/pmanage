using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Core
{
    public interface IClientRepository
    {
        Task<Client> AddClient(Client entity);
        Task<List<Client>> GetClients();
    }
}
