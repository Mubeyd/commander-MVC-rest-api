using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // source --> target
            CreateMap<Command, CommandReadDto>(); // for read data
            CreateMap<CommandCreateDto, Command>(); // for create data
            CreateMap<CommandUpdateDto, Command>(); // for update data
            CreateMap<Command, CommandUpdateDto>(); // for patch data
        }
    }
}