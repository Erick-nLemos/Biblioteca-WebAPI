using FirstAPICSharp.Dtos.Livro;
using FirstAPICSharp.models;

namespace FirstAPICSharp.Services.Livro
{
    public class LivroServices : ILivroInterface
    {
        public Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int IdLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<LivroModel>> GetLivroPorId(int IdLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            throw new NotImplementedException();
        }
    }
}
