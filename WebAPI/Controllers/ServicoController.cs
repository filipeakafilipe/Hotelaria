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
    public class ServicoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IServicosRepository<ServicoVO> _context;

        /// <summary>
        /// Responsável por endpoints referentes ao Serviço
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        public ServicoController(IMediator mediator, IServicosRepository<ServicoVO> context)
        {
            _mediator = mediator;
            _context = context;
        }

        /// <summary>
        /// Retorna serviço por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoVO>> GetById(int id)
        {
            try
            {
                var servico = await _mediator.Send(new GetServicoByIdQuery(id));

                if (servico == null)
                {
                    return NotFound();
                }

                return Ok(servico);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna todos serviços
        /// </summary>
        /// <returns></returns>
        [HttpGet("todos")]
        public async Task<ActionResult<List<ServicoVO>>> GetTodos()
        {
            try
            {
                var servicos = await _mediator.Send(new GetTodosServicosQuery());

                if (servicos.Count == 0)
                {
                    return NotFound();
                }

                return Ok(servicos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cadastrar novo serviço
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CadastraServicoCommand command)
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
        /// Atualiza as informações de um serviço
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizaServicoCommand command)
        {
            try
            {
                command.Id = id;

                var response = await _mediator.Send(command);

                if (response == ResultadoOperacaoMessage.NaoEncontrado)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletar as informações de um serviço
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeletaServicoCommand { Id = id });

                if (response == ResultadoOperacaoMessage.NaoEncontrado)
                {
                    return NotFound();
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
