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
    public class ComandaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IComandasRepository<ComandaVO> _context;

        /// <summary>
        /// Responsável por endpoints referentes às Comandas
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        public ComandaController(IMediator mediator, IComandasRepository<ComandaVO> context)
        {
            _mediator = mediator;
            _context = context;
        }


        /// <summary>
        /// Retorna comanda por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ComandaVO>> GetById(int id)
        {
            try
            {
                var comanda = await _mediator.Send(new GetComandaByIdQuery(id));

                if (comanda == null)
                {
                    return NotFound();
                }

                return Ok(comanda);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna todas comandas
        /// </summary>
        /// <returns></returns>
        [HttpGet("todos")]
        public async Task<ActionResult<List<ComandaVO>>> GetTodos()
        {
            try
            {
                var comandas = await _mediator.Send(new GetTodasComandasQuery());

                if (comandas.Count == 0)
                {
                    return NotFound();
                }

                return Ok(comandas);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cadastrar nova comanda
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CadastraComandaCommand command)
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
        /// Atualiza as informações de uma comanda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizaComandaCommand command)
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
        /// Deletar as informações de uma comanda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeletaComandaCommand { Id = id });

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
