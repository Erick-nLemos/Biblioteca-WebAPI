using FirstAPICSharp.Data;
using FirstAPICSharp.Dtos.Autor;
using FirstAPICSharp.models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPICSharp.Services.Autor
{
    public class AutorServices : IAutorInterface
    {
        private readonly AppDbContext context;
        public AutorServices(AppDbContext context) {
        
            this.context = context;
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = new AutorModel()
                {
                    Name = autorCriacaoDto.Name,
                    LastName = autorCriacaoDto.LastName
                };

                context.Add(autor);
                await context.SaveChangesAsync();

                resposta.Dados = await context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com Sucesso!";
                return resposta;

            } catch (Exception ex) { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> GetAutorPorId(int IdAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                // metodo FirstOrDefaultAsync para pegar o primeiro registro que obedece a regra (cada autorBanco deve ser == a IdAutor)
                var autor = await this.context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == IdAutor);
                if (autor == null) {
                    resposta.Mensagem = "Autor not Fund!";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor Localizado!";

                return resposta; 
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> GetAutorPorIdLivro(int IdLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var livro = await this.context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == IdLivro);
                if (livro == null) {
                    resposta.Mensagem = "Autor Not Found!";
                    return resposta;
                }
                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor encontrado!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await this.context.Autores.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram coletados!";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
