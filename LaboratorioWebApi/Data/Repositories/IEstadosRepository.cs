namespace LaboratorioWebApi.Data.Repositories
{
    public interface IEstadosRepository
    {
        Task<List<string>> ObtenerNombresEstadosAsync();
    }
}
