using AutoMapper;
using FieldEdge.Services.Object_Provider;
using FieldEdge.API.Object_Provider;


namespace FieldEdge.Server.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FieldEdge.Services.Object_Provider.Customer, FieldEdge.API.Object_Provider.Customer>();
            CreateMap<FieldEdge.API.Object_Provider.Customer, FieldEdge.Services.Object_Provider.Customer>();
        }
    }
}
