using ApiConciertos.Models.DTOs;
using ApiConciertos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertos.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var result = authService.Register(model.Email, model.Password, model.Role);

            return Ok(result);
        }

        
    }
}

