using FirstAPICSharp.Dtos.Autor;
using FirstAPICSharp.models;
using FirstAPICSharp.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPICSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface autorInterface;
        public AutorController(IAutorInterface autorInterface) { 
            
            this.autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await this.autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("GetAutorPorId/{IdAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> GetAutor(int IdAutor)
        {
            var autor = await this.autorInterface.GetAutorPorId(IdAutor);
            return Ok(autor);
        }

        [HttpGet("GetAutorPorIdLivro/{IdLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> GetAutorPorLivro(int IdLivro)
        {
            var autor = await this.autorInterface.GetAutorPorIdLivro(IdLivro);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autores);
        }

    }
}
