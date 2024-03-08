﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Responses;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpGet]
        public async Task<Response> GetUsers([FromQuery] int? id, [FromQuery] int from = 0, [FromQuery] int to = 10)
        {
            return new Response();
        }


        [HttpPost]
        public async Task<Response> AddUser()
        {
            return new Response();
        }

        [HttpPut]
        public async Task<Response> UpdateUser()
        {
            return new Response();
        }

        [HttpDelete]
        public async Task<Response> DeleteUser()
        {
            return new Response();
        }



    }
}
