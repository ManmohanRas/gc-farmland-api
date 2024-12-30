namespace PresTrust.FarmLand.Application.Commands;

public class EnableSadcCommandMappingProfile : Profile 
{
    
    
        public EnableSadcCommandMappingProfile()
        {
            CreateMap<EnableSadcCommand, FarmApplicationEntity>()
                // Optional: Specify how individual properties map if they don't have matching names
                .ForMember(dest => dest.IsSADC, opt => opt.MapFrom(src => src.ApplicationId))
                // Add other property mappings as necessary
                ;
        }
    
}
