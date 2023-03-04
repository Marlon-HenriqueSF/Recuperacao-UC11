using Chapter.WebAPI.Interfaces;
using Chapter.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        public UsuarioController(IUsuarioRepository iUsuarioRepository) 
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        [HttpGet]
        public IActionResult ListarUsuario()
        {
            try
            {
                return Ok(_iUsuarioRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario) 
        {
            try
            {
                _iUsuarioRepository.Atualizar(id, usuario);
                return Ok("Usuario Atualizado com Sucesso !");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarUsuarioPorId(int id)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.BuscarPorId(id);
                if (usuarioBuscado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioBuscado);
            }
            catch (Exception)
            {

                throw;
            } 
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                _iUsuarioRepository.Deletar(id);
                return Ok("Usuario Excluido com Sucesso !");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
