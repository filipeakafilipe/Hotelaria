using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotelaria.Application.Commands;
using Hotelaria.Application.Messages;
using Hotelaria.Application.Models;
using Hotelaria.Application.Queries;
using Hotelaria.Application.Queries.Usuario;
using Hotelaria.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotelaria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsuariosRepository<UsuarioVO> _context;

        /// <summary>
        /// Responsável por endpoints referentes ao Usuário
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        public UsuarioController(IMediator mediator, IUsuariosRepository<UsuarioVO> context)
        {
            _mediator = mediator;
            _context = context;
        }

        /// <summary>
        /// Retorna um usuário por seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioVO>> GetById(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetUsuarioByIdQuery(id));

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna usuários com um CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<List<UsuarioVO>>> GetByCpf(string cpf)
        {
            try
            {
                var users = await _mediator.Send(new GetUsuarioByCpfQuery(cpf));

                if (users.Count == 0)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna usuário por seu login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet("login/{login}")]
        public async Task<ActionResult<UsuarioVO>> GetByLogin(string login)
        {
            try
            {
                var user = await _mediator.Send(new GetUsuarioByLoginQuery(login));

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna todos usuários cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("todos")]
        public async Task<ActionResult<List<UsuarioVO>>> GetTodos()
        {
            try
            {
                var users = await _mediator.Send(new GetTodosUsuariosQuery());

                if (users.Count == 0)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cadastrar novo usuário
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CadastraUsuarioCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Atualiza as informações de um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizaUsuarioCommand command)
        {
            try
            {
                command.Id = id;

                var response = await _mediator.Send(command);

                if (response == ResultadoOperacaoMessage.NaoEncontrado)
                {
                    return NotFound();
                }
                if (response == ResultadoOperacaoMessage.ErroInterno)
                {
                    return BadRequest();
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletar as informações de um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeletaUsuarioCommand { Id = id });

                if (response == ResultadoOperacaoMessage.NaoEncontrado)
                {
                    return NotFound();
                }
                if (response == ResultadoOperacaoMessage.ErroInterno)
                {
                    return BadRequest();
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
