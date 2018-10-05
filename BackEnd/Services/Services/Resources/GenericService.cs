using AutoMapper;
using Core;
using Core.Entities;
using Infrastructure.DAL;
using Infrastructure.DAL.Interfaces;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Resources
{
    public class GenericService
    {
        //private IMapper _mapper;
        //private UnitOfWork _unitOfWork;

        //public GenericService(IMapper mapper, UnitOfWork unitOfWork)
        //{
        //    _mapper = mapper;
        //    _unitOfWork = unitOfWork;

        //}

        //public async Task<IEnumerable<PersonaDTO>> GetAll()
        //{
        //    // var result = await _personaRepository.GetPersonas();
        //    var r = await _unitOfWork.PersonaRepository.Get(p => p.Deleted != true, orderBy: o => o.OrderBy(s => s.Id));
        //    return _mapper.Map<IEnumerable<Persona>, IEnumerable<PersonaDTO>>(r);
        //}

        //public async Task<PersonaDTO> GetById(int id)
        //{
        //    var result = await _unitOfWork.PersonaRepository.GetByID(id);
        //    //var result = await _personaRepository.GetPersonaByID(id);
        //    return _mapper.Map<Persona, PersonaDTO>(result);
        //}

        //public virtual async Task Add(PersonaDTO entity)
        //{
        //    var e = _mapper.Map<PersonaDTO, Persona>(entity);
        //    //_personaRepository.InsertPersona(_mapper.Map<PersonaDTO, Persona>(entity));
        //    _unitOfWork.PersonaRepository.Insert(e);
        //    await _unitOfWork.Save();

        //}

        //public virtual async Task Update(int id, PersonaDTO entity)
        //{
        //    var e = _mapper.Map<PersonaDTO, Persona>(entity);
        //    // var toUpdate = await _personaRepository.GetPersonaByID(id);
        //    //var toUpdate = await _unitOfWork.PersonaRepository.GetByID(id);
        //    //var toUpdate = _mapper.Map(e, toUpdate);
        //    // _personaRepository.UpdatePersona(id, _mapper.Map(entity, toUpdate));
        //    _unitOfWork.PersonaRepository.Update(e);
        //    await _unitOfWork.Save();
        //}

        //public virtual async Task<PersonaDTO> Delete(int id)
        //{
        //    //return await _personaRepository.DeletePersonaById(id);
        //    var result = await _mapper.Map<Task<Persona>, Task<PersonaDTO>>(_unitOfWork.PersonaRepository.Delete(id));
        //    await _unitOfWork.Save();
        //    return result;
        //}
    }
}
