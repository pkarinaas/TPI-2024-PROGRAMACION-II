using LaboratorioWebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Data.Repositories
{
    public class DetallesMuestrasRepository : IDetallesMuestrasRepository
    {
        private LaboratorioDbContext _context;
        public DetallesMuestrasRepository(LaboratorioDbContext context)
        {
            _context = context;
        }
        public bool CreateDetalleMuestra(DetallesMuestras detalle)
        {
            _context.DetallesMuestras.Add(detalle);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> UpdateDetallesMuestrasAsync(DetallesMuestras muestra)
        {
            var entity = await _context.DetallesMuestras.FindAsync(muestra.IdDetallesMuestras);

            if (entity == null)
                return false;

            entity.Detalle = muestra.Detalle;
            entity.CodNbu = muestra.CodNbu;
            entity.IdMuestra = muestra.IdMuestra;
            entity.IdTipoEstado = muestra.IdTipoEstado;

            await _context.SaveChangesAsync();
            return true;
        }

        public List<DetallesMuestras> GetDetallesMuestras()
        {
            return _context.DetallesMuestras.ToList();
        }

        public async Task<List<MuestraConsultaResultado>> GetDetallesMuestrasAsync()
        {
            var resultados = await _context.DetallesMuestras
        .Select(dm => new MuestraConsultaResultado
        {
            NumeroMuestra = dm.IdDetallesMuestras,
            Practica = dm.CodNbuNavigation.NomPractica,
            DerivadaA = dm.CodNbuNavigation.DerivadaANavigation.NombreLaboratorioDerivado,
            Estado = dm.IdTipoEstadoNavigation.Estado
        })
        .ToListAsync();

            return resultados;
        }


        public bool UpdateDetallesMuestras(int id)
        {
            var detalleMuestraUpdated = _context.DetallesMuestras.Find(id);
            if (detalleMuestraUpdated != null)
            {
                ;
                _context.DetallesMuestras.Update(detalleMuestraUpdated);
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
