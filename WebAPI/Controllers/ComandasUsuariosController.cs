using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotelaria.Application.Commands;
using Hotelaria.Application.Messages;
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
    public class ComandasUsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IComandasUsuariosRepository<ComandasUsuariosVO> _context;

        /// <summary>
        /// Responsável por endpoints referentes às aos Usuários anexados às Comandas
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        public ComandasUsuariosController(IMediator mediator, IComandasUsuariosRepository<ComandasUsuariosVO> context)
        {
            _mediator = mediator;
            _context = context;
        }


        /// <summary>
        /// Retorna um usuário da comanda por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ComandasUsuariosVO>> GetById(int id)
        {
            try
            {
                var comandaUsuario = await _mediator.Send(new GetComandaUsuarioByIdQuery(id));

                if (comandaUsuario == null)
                {
                    return NotFound();
                }

                return Ok(comandaUsuario);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna todos usuários anexados a comandas
        /// </summary>
        /// <returns></returns>
        [HttpGet("todos")]
        public async Task<ActionResult<List<ComandasUsuariosVO>>> GetTodos()
        {
            try
            {
                var comandasUsuarios = await _mediator.Send(new GetTodasComandasUsuariosQuery());

                if (comandasUsuarios.Count == 0)
                {
                    return NotFound();
                }

                return Ok(comandasUsuarios);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cadastrar novo usuário em uma comanda
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CadastraComandaUsuarioCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);

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
        /// Atualiza as informações de um usuário de uma comanda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizaComandaUsuarioCommand command)
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
        /// Deletar as informações de um usuário de uma comanda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeletaComandaUsuarioCommand { Id = id });

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
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
