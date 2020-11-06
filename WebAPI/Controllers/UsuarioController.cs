using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotelaria.Application.Commands;
using Hotelaria.Application.Models;
using Hotelaria.Application.Queries;
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
        private readonly IRepository<UsuarioVO> _context;

        /// <summary>
        /// Responsável por métodos referentes ao Usuário
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        public UsuarioController(IMediator mediator, IRepository<UsuarioVO> context)
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
                var user = await _mediator.Send(new GetUsuarioQuery(id));

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch
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
            catch
            {
                return BadRequest();
            }
        }
    }
}
