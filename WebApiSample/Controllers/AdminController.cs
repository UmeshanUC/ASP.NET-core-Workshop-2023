using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.DTOs;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public AdminController(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null) {
                return BadRequest();
            }

            User registringUser = mapper.Map<User>(registerDto);
            registringUser.Role= "admin";

            var result = await userManager.CreateAsync(registringUser, registerDto.Password);

            if (result.Succeeded)
            {
                User createdAdmin = await userManager.FindByEmailAsync(registringUser.Email);
                UserReturnDto userReturnDto = mapper.Map<UserReturnDto>(createdAdmin);
                return Created(userReturnDto.Id, userReturnDto);
            }

            return BadRequest(result.Errors);
        }

    }
}
