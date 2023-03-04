using Chapter.WebAPI.Interfaces;
using Chapter.WebAPI.Models;
using Chapter.WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _iLivroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _iLivroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iLivroRepository.Ler());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [Authorize(Roles = "7")]
        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _iLivroRepository.Cadastrar(livro);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Atualizar(int id, Livro livro)
        {
            try
            {
                _iLivroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _iLivroRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Livro livro = _iLivroRepository.BuscarPorId(id);
                if (livro == null)
                { 
                    return NotFound();
                }
                return Ok(livro);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
