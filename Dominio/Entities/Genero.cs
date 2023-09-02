using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Genero : BaseEntity
    {
        public string NombreGenero { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}