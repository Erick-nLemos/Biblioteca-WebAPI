using FirstAPICSharp.Data;
using FirstAPICSharp.Dtos.Livro;
using FirstAPICSharp.models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPICSharp.Services.Livro
{
    public class LivroServices : ILivroInterface
    {
        private readonly AppDbContext context;

        public LivroServices(AppDbContext context) {
            this.context = context;
        }
        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo
                };
                context.Add(livro);
                await context.SaveChangesAsync();

                resposta.Dados = await context.Livros.ToListAsync();
                resposta.Mensagem = "Livro Salvo!";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroEdicaoDto.Id);
                if (livro == null)
                {
                    resposta.Mensagem = "Autor not Found!";
                    return resposta;
                }
                livro.Titulo = livroEdicaoDto.Titulo;
                context.Update(livro);
                await context.SaveChangesAsync();

                resposta.Mensagem = "Livro Atualizado!";
                return resposta;
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int IdLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == IdLivro);
                if (livro == null) {
                    resposta.Mensagem = "Livro not Found!";
                    return resposta;
                }
                context.Remove(livro);
                await context.SaveChangesAsync();

                resposta.Dados = await context.Livros.ToListAsync();
                resposta.Mensagem = "Livro Excluido com Sucesso!";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> GetLivroPorId(int IdLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == IdLivro);
                if(livro == null)
                {
                    resposta.Mensagem = "Livro not Found!";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro encontrado";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await context.Livros.ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Livros encontrados!";
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
