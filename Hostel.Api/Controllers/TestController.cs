﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hostel.Api.Controllers.Base;
using Hostel.Application.Test.Commands;
using Hostel.Application.Test.Queries.GetTest;
using Hostel.Application.Test.Queries.GetTestByCondition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hostel.Api.Controllers
{
    public class TestController : BaseController
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetTestQuery());

            return Ok(response);
        }

        [HttpGet("GetBy")]
        public async Task<IActionResult> GetBy(int id) => Ok(await Mediator.Send(new GetTestByConditionQuery(id)));
        

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTestEntity(CreateTestCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
