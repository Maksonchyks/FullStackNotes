using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFullStackNotes.Api.DTO.User;
using MyFullStackNotes.Application.Interfaces;
using MyFullStackNotes.Domain.Entities;
using MyFullStackNotes.Domain.Enums;

namespace MyFullStackNotes.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Owner")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if(user == null) return NotFound();

            if (user.Role == UserRole.Owner && User.IsInRole("Admin"))
                return Forbid();

            await _userService.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("by-email")]
        public async Task<ActionResult<User?>> GetByEmail([FromQuery] string email) 
        {
            var user = await _userService.GetByEmailAsync(email);
            if (user == null) return NotFound();    

            return Ok(user);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<User>> GetById([FromRoute] Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }


        [HttpPatch("update/{id}")]
        public async Task<ActionResult<User>> Update([FromRoute] Guid id, [FromBody] UpdateRoleRequest updateRequest)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            if (user.Role == UserRole.Owner && User.IsInRole("Admin"))
                return Forbid();

            await _userService.UpdateRoleAsync(id, updateRequest.UserRole);
            return Ok();
        }
    }
}
