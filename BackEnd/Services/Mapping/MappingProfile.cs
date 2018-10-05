using AutoMapper;
using Core.Entities;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonaDTO, Persona>().ReverseMap();

        }
    }
}
