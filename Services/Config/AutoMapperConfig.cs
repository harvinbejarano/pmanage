using AutoMapper;
using Repositories.Entities;
using Services.DTO;

namespace Services.Config
{
    public static class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Client, ClientDTO>().ReverseMap();
            });

            return  config.CreateMapper();
        }
    }
}
