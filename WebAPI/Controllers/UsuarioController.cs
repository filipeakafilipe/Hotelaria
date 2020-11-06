﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotelaria.Application.Commands;
using Hotelaria.Application.Models;
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
        private readonly IRepository<Usuario> _context;

        public UsuarioController(IMediator mediator, IRepository<Usuario> context)
        {
            _mediator = mediator;
            _context = context;
        }

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
