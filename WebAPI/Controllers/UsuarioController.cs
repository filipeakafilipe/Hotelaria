using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotelaria.Application.Commands;
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
        /// Responsável por métodos referentes ao Usuário
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
        public async Task<ActionResult<UsuarioVO>> Get(int id)
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
        public async Task<ActionResult<List<UsuarioVO>>> Get(string cpf)
        {
            try
            {
                var users = await _mediator.Send(new GetUsuarioByCpfQuery(cpf));

                if(users.Count == 0)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception ex)
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
    }
}
