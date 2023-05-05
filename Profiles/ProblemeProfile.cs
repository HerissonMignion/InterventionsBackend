using AutoMapper;
using InterventionsBackend.Entities;
using InterventionsBackend.Models;

namespace InterventionsBackend.Profiles;

public class ProblemeProfile : Profile {


    public ProblemeProfile() {
        CreateMap<TypeProbleme, TypeProblemeDTO>();
    }

}






