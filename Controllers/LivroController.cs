using FirstAPICSharp.Dtos.Livro;
using FirstAPICSharp.models;
using FirstAPICSharp.Services.Livro;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPICSharp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface livroInterface;

        public LivroController(ILivroInterface livroInterface) {
            this.livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> GetLivros() {
            var livros = await this.livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("ListarLivros/{IdLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> GetLivroPorId(int IdLivro) {
            var livro = await this.livroInterface.GetLivroPorId(IdLivro);
            return Ok(livro);
        }

        [HttpPost("CriarLivros")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livro = await this.livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livro);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livro = await this.livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livro);
        }

        [HttpDelete("DeletarLivro/{IdLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ExcluirLivro(int IdLivro)
        {
            var livros = await this.livroInterface.ExcluirLivro(IdLivro);
            return Ok(livros);
        }
    }
}
