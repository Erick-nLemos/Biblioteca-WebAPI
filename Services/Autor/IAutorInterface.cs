using FirstAPICSharp.models;
using FirstAPICSharp.Dtos.Autor;

namespace FirstAPICSharp.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> GetAutorPorId(int IdAutor);
        Task<ResponseModel<AutorModel>> GetAutorPorIdLivro(int IdLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int IdAutor);
    }
}
