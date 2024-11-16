using LaboratorioWebApi.Data.Entities;

namespace LaboratorioWebApi.Data.Repositories
{
    public class MuestrasRepository : IMuestrasRepository
    {
        private LaboratorioDbContext _context;
        public MuestrasRepository(LaboratorioDbContext context)
        {
            _context = context;
        }

        public bool Create(Muestras muestra)
        {
            _context.Muestras.Add(muestra);
            return _context.SaveChanges() == 1;
        }

        public List<Muestras> GetAll()
        {
            return _context.Muestras.ToList();
        }

        public List<Muestras> GetByEstado(int idTipoEstado)
        {
            
            return _context.Muestras.Where(m => m.IdTipoEstado == idTipoEstado).ToList();
        }

        public Muestras? GetById(int id)
        {
            return _context.Muestras.Find(id);
        }

        public bool Update(int id, int nuevoEstado)
        {
            var muestraUpdated = _context.Muestras.Find(id);
            if (muestraUpdated != null)
            {
                muestraUpdated.IdTipoEstado = nuevoEstado;
                _context.Muestras.Update(muestraUpdated);
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
