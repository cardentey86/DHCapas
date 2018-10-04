using AutoMapper;
using Core.Entities;
using Infrastructure.DAL.Interfaces;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Resources
{
    public class PersonaService
    {
        private IMapper _mapper;
        IPersonasRepository _personaRepository;

        public PersonaService(IPersonasRepository personasRepository, IMapper mapper)
        {
            _mapper = mapper;
            _personaRepository = personasRepository;
        }

        public async Task<IEnumerable<PersonaDTO>> GetAll()
        {
            var result = await _personaRepository.GetPersonas();
            return _mapper.Map<IEnumerable<Persona>, IEnumerable<PersonaDTO>>(result);
        }

        public virtual async Task Add(PersonaDTO entity)
        {
           // FillDefaultValues(entity);
            var e = _mapper.Map<PersonaDTO, Persona>(entity);
            _personaRepository.InsertPersona(_mapper.Map<PersonaDTO, Persona>(entity));
            _personaRepository.Save();
        }
       
    }
}
