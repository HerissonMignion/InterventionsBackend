using AutoMapper;
using InterventionsBackend.Entities;
using InterventionsBackend.Models;

namespace InterventionsBackend.Profiles;

public class ProblemeProfile : Profile {


    public ProblemeProfile() {
        CreateMap<TypeProbleme, TypeProblemeDTO>();
        CreateMap<ProblemeDTO, Probleme>().ReverseMap()
            .ForMember(dest => dest.descriptionTypeProbleme,
            opt => opt.MapFrom
            (src => src.TypeProbleme.descriptionTypeProbleme));
        // CreateMap<ProblemeDTO, Probleme>();
    }

}






