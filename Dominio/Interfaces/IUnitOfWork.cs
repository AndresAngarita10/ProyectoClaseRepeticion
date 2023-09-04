using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        IPaisRepository Paises { get; }
        IDepartamentoRepository Departamentos { get; }
        ICiudadRepository Ciudades { get; }
        Task<int> SaveAsync();
    }
}