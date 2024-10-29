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
        public async Task<ActionResult<ResponseModel<AutorModel>>> GetAutor(int idAutor)
        {
            var autor = await this.autorInterface.GetAutorPorId(idAutor);
            return Ok(autor);
        } 

    }
}
