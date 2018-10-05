using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.DAL.Interfaces
{
    public interface IPersonasRepository: IDisposable
    {
        Task<IEnumerable<Persona>> GetPersonas();
        Task<Persona> GetPersonaByID(int Id);
        void InsertPersona(Persona persona);
        Task<bool> DeletePersonaById(int ID);
        Task<bool> DeletePersona(Persona persona);
        void SafeDeletePersona(int id);
        void UpdatePersona(int id, Persona persona);
        bool PersonaExist(int id);
        void Save();
    }
}
