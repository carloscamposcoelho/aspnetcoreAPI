using AspnetcoreAPI.Dto;
using AspnetcoreAPI.Models;
using AutoMapper;

namespace AspnetcoreAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandDtoRead>();
        }

    }
}