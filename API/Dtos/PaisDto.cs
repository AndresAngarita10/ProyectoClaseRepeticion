using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace API.Dtos
{
    public class PaisDto : BaseEntity
    {
        public string NombrePais { get; set; }
        public List<DepartamentoDto> Departamentos { get; set; }
    }
}