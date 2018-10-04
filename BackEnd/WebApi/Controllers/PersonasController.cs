using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.DataContext;
using Infrastructure.DAL.Interfaces;
using Services.Services.Resources;
using Services.DTO;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Personas")]
    public class PersonasController : Controller
    {
        private readonly RHDbContext _context;
        private IPersonasRepository _personaRepository;
        private PersonaService _personaService;

        public PersonasController(RHDbContext context, IPersonasRepository personaRepository, PersonaService personaService)
        {
            _context = context;
            _personaRepository = personaRepository;
            _personaService = personaService;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<IEnumerable<PersonaDTO>> GetPersonas()
        {
            // return await _personaRepository.GetPersonas();
            return await _personaService.GetAll();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersona([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var persona = await _personaRepository.GetPersonaByID(id);
            var persona = await _personaService.GetById(id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona([FromRoute] int id, [FromBody] PersonaDTO persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           // var per = await _personaRepository.GetPersonaByID(id);

            if (id != persona.Id)
            {
                return BadRequest();
            }            

            try
            {
                //_personaRepository.UpdatePersona(id, persona);
                //_personaRepository.Save();

               await _personaService.Update(id, persona);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Personas
        [HttpPost]
        public async Task<IActionResult> PostPersona([FromBody] PersonaDTO persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_personaRepository.InsertPersona(persona);
            //_personaRepository.Save();

            await _personaService.Add(persona);

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        // PUT: api/Personas/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> SafeDeletePersona([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        _personaRepository.SafeDeletePersona(id);
        //        _personaRepository.Save();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PersonaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var persona = await _personaRepository.GetPersonaByID(id);
            var persona = await _personaService.GetById(id);

            if (persona == null)
            {
                return NotFound();
            }

            await _personaService.Delete(id);
           // await _personaRepository.DeletePersonaById(id);
           // _personaRepository.Save();

            return Ok(persona);
        }

        private bool PersonaExists(int id)
        {
            return _personaRepository.PersonaExist(id);
        }
    }
}