
using Core.Entities;
using Infrastructure.DAL.Interfaces;
using Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DAL.Repositories
{
    public class PersonaRepository : IPersonasRepository, IDisposable
    {
        private RHDbContext _context;
        private bool disposed = false;

        public PersonaRepository(RHDbContext context)
        {
            _context = context;
        }      
        
        public async Task<bool> DeletePersonaById(int ID)
        {
            Persona person = await _context.Personas.FirstOrDefaultAsync(p => p.Id == ID);
            _context.Personas.Remove(person);
            Save();
            return true; 
        }

        public async Task<bool> DeletePersona(Persona persona)
        {
            Persona person = await _context.Personas.FirstOrDefaultAsync(p => p.Id == persona.Id);
            _context.Personas.Remove(person);
            return true;
        }

        public async Task<Persona> GetPersonaByID(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Id == id && p.Deleted == false);
            return persona;
        }

        public async Task<IEnumerable<Persona>> GetPersonas()
        {
            return await _context.Personas.Where(p => p.Deleted == false).ToListAsync();
        }

        public void InsertPersona(Persona persona)
        {
            persona.CreatedDate = DateTime.UtcNow;
            persona.ModifiedDate = DateTime.UtcNow;
            _context.Personas.Add(persona);
            Save();
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public void UpdatePersona(int id, Persona persona)
        {
            //var per = _context.Personas.FirstOrDefault(p => p.Id == id);
            persona.ModifiedDate = DateTime.UtcNow;
            _context.Entry(persona).State = EntityState.Modified;
            Save();
            
        }

        public void SafeDeletePersona(int id)
        {
            var persona = _context.Personas.FirstOrDefault(p => p.Id == id);
            if(persona != null)
            {
                persona.Deleted = true;
                persona.ModifiedDate = DateTime.UtcNow;
            }           
            
            _context.Entry(persona).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool PersonaExist(int id)
        {
            if (GetPersonaByID(id)!=null)
                return true;
            return false;
        }

        
    }
}
