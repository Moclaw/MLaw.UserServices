using Microsoft.AspNetCore.Mvc;
using MLaw.UserServices.Application.Contracts.IServices;
using MLaw.UserServices.Application.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLaw.UserServices.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : UserServicesController
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            return Ok(await _userServices.GetUserRequest(1));
        }
        [HttpPost]
        public async ValueTask<IActionResult> Post([FromBody] UserRequest request)
        {
            return Ok(await _userServices.CreateUserRequest(request));
        }
    }
}
