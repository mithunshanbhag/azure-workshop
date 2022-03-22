namespace AzureWorkshop.CodeSamples.FunctionApps.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region DAO (storage) models to DTO (REST) models

        CreateMap<ContactDao, ContactDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id));

        #endregion

        #region DTO (REST) models to DAO (storage) models

        CreateMap<ContactDto, ContactDao>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id));

        #endregion
    }
}