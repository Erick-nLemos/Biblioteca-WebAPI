using FirstAPICSharp.models;

namespace FirstAPICSharp.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> GetAutorPorId(int IdAutor);
        Task<ResponseModel<AutorModel>> GetAutorPorIdLivro(int IdLivro);
    }
}
