using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBRQ.API.Data.Repository.Interface;
using TesteBRQ.API.Entities;

namespace TesteBRQ.API.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            try
            {
                var usuarios = _usuarioRepository.GetUsuarios().ToList();
                return usuarios;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar lista de Usuários");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            try
            {
                var usuario = _usuarioRepository.GetUsuarioPorId(id);
                return Ok(usuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar um Usuário");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepository.AddUsuario(usuario);
                return Ok("Usuário cadastrado com Sucesso");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao cadastrar um Usuário");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody]Usuario usuario)
        {
            try
            {
                if(usuario.Id != id)
                {
                    return BadRequest($"Não foi possivel atualizar o usuário com id={id}");
                }

                _usuarioRepository.Update(usuario);
                return Ok($"Usuário com id={id} foi atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar um Usuário");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Delete(id);
                return Ok("Usuário deletado com Sucesso");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar um Usuário");
            }
        }
    }
}
