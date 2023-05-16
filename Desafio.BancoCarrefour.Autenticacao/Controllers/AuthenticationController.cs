
using Desafio.BancoCarrefour.Authentication.DTOs;
using Desafio.BancoCarrefour.Authentication.Services.Implementations;
using Desafio.BancoCarrefour.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.Authentication.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        

        public AuthenticationController(ILogger<AuthenticationController> logger, IConfiguration configuration, ITokenService tokenService)
        {
            _logger = logger;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("token")]
        public async Task<ActionResult<LoginReturnDTO>> GenerateToken([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var tokenReturn = await _tokenService.GenerateToken(loginDTO);
                if(tokenReturn.Error != null)
                {
                    return BadRequest(tokenReturn);
                }
                return Ok(tokenReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginReturnDTO { Error = new ErrorBaseDTO { Codigo = "001", Mensagem = $"Ocorreu um erro inesperado: {ex.Message}" } });
            }
        }
        [HttpPost("refreshtoken")]
        public async Task<ActionResult<LoginReturnDTO>> RefreshToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            try
            {
                var tokenReturn = await _tokenService.RefreshToken(refreshTokenDTO);
                if (tokenReturn.Error != null)
                {
                    return BadRequest(tokenReturn);
                }
                return Ok(tokenReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginReturnDTO { Error = new ErrorBaseDTO { Codigo = "001", Mensagem = $"Ocorreu um erro inesperado: {ex.Message}" } });
            }
        }


    }
}
