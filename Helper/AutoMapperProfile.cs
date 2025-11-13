using AutoMapper;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Contacto, ContactoDto>();
        CreateMap<ContactoDto, Contacto>(); 
    }
}