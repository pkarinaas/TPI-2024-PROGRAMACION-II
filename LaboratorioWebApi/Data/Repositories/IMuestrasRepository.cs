using LaboratorioWebApi.Data.Entities;

namespace LaboratorioWebApi.Data.Repositories
{
    public interface IMuestrasRepository
    {
        bool Create(Muestras muestra);
        List<Muestras> GetAll();
        Muestras? GetById(int id);
        List<Muestras> GetByEstado(int estado);
        bool Update(int id, int nuevoEstado);
    }
}
