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
    public class ComandasServicosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IComandasServicosRepository<ComandasServicosVO> _context;

        /// <summary>
        /// Responsável por endpoints referentes às aos Serviços anexadas às Comandas
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        public ComandasServicosController(IMediator mediator, IComandasServicosRepository<ComandasServicosVO> context)
        {
            _mediator = mediator;
            _context = context;
        }


        /// <summary>
        /// Retorna serviços da comanda por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ComandasServicosVO>> GetById(int id)
        {
            try
            {
                var comandaServico = await _mediator.Send(new GetComandaServicoByIdQuery(id));

                if (comandaServico == null)
                {
                    return NotFound();
                }

                return Ok(comandaServico);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna todos serviços anexadas às comandas
        /// </summary>
        /// <returns></returns>
        [HttpGet("todos")]
        public async Task<ActionResult<List<ComandasServicosVO>>> GetTodos()
        {
            try
            {
                var comandasServicos = await _mediator.Send(new GetTodasComandasServicosQuery());

                if (comandasServicos.Count == 0)
                {
                    return NotFound();
                }

                return Ok(comandasServicos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cadastrar novo serviço em uma comanda
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CadastraComandaServicoCommand command)
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
        /// Atualiza as informações de um serviço de uma comanda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizaComandaServicoCommand command)
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
        /// Deletar as informações de um serviço de uma comanda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeletaComandaServicoCommand { Id = id });

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
