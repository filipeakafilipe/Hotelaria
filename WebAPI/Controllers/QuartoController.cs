using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotelaria.Application.Commands;
using Hotelaria.Application.Messages;
using Hotelaria.Application.Models;
using Hotelaria.Application.Queries;
using Hotelaria.Domain.Interfaces;
using Hotelaria.Infrastructure.Mapping;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotelaria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IQuartosRepository<QuartoVO> _context;

        /// <summary>
        /// Responsável por endpoints referentes ao Usuário
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        public QuartoController(IMediator mediator, IQuartosRepository<QuartoVO> context)
        {
            _mediator = mediator;
            _context = context;
        }

        /// <summary>
        /// Retorna quarto por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<QuartoVO>> GetById(int id)
        {
            try
            {
                var quarto = await _mediator.Send(new GetQuartoByIdQuery(id));

                if (quarto == null)
                {
                    return NotFound();
                }

                return Ok(quarto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna todos quartos
        /// </summary>
        /// <returns></returns>
        [HttpGet("todos")]
        public async Task<ActionResult<List<QuartoVO>>> GetTodos()
        {
            try
            {
                var quartos = await _mediator.Send(new GetTodosQuartosQuery());

                if (quartos.Count == 0)
                {
                    return NotFound();
                }

                return Ok(quartos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cadastrar novo quarto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CadastraQuartoCommand command)
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

        ///// <summary>
        ///// Atualiza as informações de um quarto
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpPatch("{id}")]
        //public async Task<ActionResult> Atualizar(int id, AtualizaQuartoCommand command)
        //{
        //    try
        //    {
        //        command.Id = id;

        //        var response = await _mediator.Send(command);

        //        if (response == ResultadoOperacaoMessage.NaoEncontrado)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(response);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        ///// <summary>
        ///// Deletar as informações de um quarto
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Deletar(int id)
        //{
        //    try
        //    {
        //        var response = await _mediator.Send(new DeletaQuartoCommand { Id = id });

        //        if (response == ResultadoOperacaoMessage.NaoEncontrado)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(response);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
