using AspnetcoreAPI.Dto;
using AspnetcoreAPI.Models;
using AutoMapper;

namespace AspnetcoreAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //source -> target
            CreateMap<Command, CommandDtoRead>();
            CreateMap<CommandDtoCreate, Command>();
            CreateMap<CommandDtoUpdate, Command>();
        }

    }
}