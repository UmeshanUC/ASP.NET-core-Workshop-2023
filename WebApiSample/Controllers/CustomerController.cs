using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.DTOs;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public CustomerController(IMapper mapper, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(string id)
        {
            User retrievedUser = await userManager.FindByIdAsync(id);
            if(retrievedUser is not null)
            {
                UserReturnDto requestedUser = mapper.Map<UserReturnDto>(retrievedUser);
                return Ok(requestedUser);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] RegisterDto registeringCustomer)
        {
            User newUser = mapper.Map<User>(registeringCustomer);

            var result = await userManager.CreateAsync(newUser, registeringCustomer.Password);

            if (result.Succeeded)
            {
                UserReturnDto userCreated = mapper.Map<UserReturnDto>(newUser);

                return Created(userCreated.Id, userCreated);
            }
            return BadRequest(result.Errors);
        }
    }
}
