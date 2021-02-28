using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSvc.Models;

namespace UserSvc.Controllers
{

    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {

        [HttpGet]       
        public async Task<IActionResult> GetUsers()
        {
            var users = new List<UserModel>() 
            { 
                new UserModel() { FullName = "Jigar Acharya", Password = "Jigar", UserName ="jigaracharya" },
                new UserModel() { FullName = "Khush Acharya", Password = "Khush", UserName ="khushacharya" }
            };
            return Ok(await Task.FromResult(users));
        }
    }
}
