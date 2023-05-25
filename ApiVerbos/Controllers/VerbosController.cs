using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verbos.Domain.Contratos;
using Verbos.Domain.Entidades;

namespace Verbos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerbosController : ControllerBase
    {
        readonly private ILocadora _locadora;

        public VerbosController(ILocadora locadora)
        {
            _locadora = locadora;
        }
        [HttpGet("ConsultarFilmes")]
        public List<Filme> ConsultarFilmes()
        {
            return _locadora.ExbirFilmes();
        }
        [HttpPost("CadastrarFilme")]
        public void CadastrarFilme([FromBody] Filme filme)
        {
            _locadora.AddFilme(filme);
        }
        [HttpDelete("ExcluirFilme")]
        public void ExcluirFilme(int id)
        {
            _locadora.DeletarFilme(id);
        }
        [HttpPatch("AlterarFilme")]
        public void AlterarFilme(Filme filme)
        {
            _locadora.alterarFilme(filme);
        }
    }
}
