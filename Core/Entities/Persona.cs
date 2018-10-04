using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Persona: Entity
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
    }
}
