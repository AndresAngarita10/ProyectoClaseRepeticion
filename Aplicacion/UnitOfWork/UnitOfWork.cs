using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiIncidenciasContext context ;
        private PaisRepository _paises;

        public UnitOfWork(ApiIncidenciasContext _context)
        {
            this.context = _context;
        }

        public IPaisRepository Paises
        {
            get{
                if(_paises == null){
                    _paises = new PaisRepository(context);
                }
                return _paises;
            }
        }

        /* public int Save(){
            return context.SaveChanges();
        } */

        public void Dispose()
        {
            context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}