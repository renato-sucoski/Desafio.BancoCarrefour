using Desafio.BancoCarrefour.FluxoCaixa.DTOs;
using Desafio.BancoCarrefour.FluxoCaixa.DTOs.Relatorio;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Interfaces;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.FluxoCaixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly ICreditoService _creditoService;
        public CreditoController(ICreditoService creditoService)
        {
            _creditoService = creditoService;
        }
        [HttpPost("Inserir")]
        public async Task<ActionResult<CreditoRetornoDTO>> Inserir([FromBody] CreditoDTO credito)
        {
            try
            {
                var UserName = HttpContext.Request.Headers["UserName"];
                if(!string.IsNullOrWhiteSpace( UserName))
                    credito.UsuarioLancamento = UserName;
                credito.DataHoraLancamentoUTC = DateTime.UtcNow;
                return Ok(await _creditoService.Inserir(credito));
            }
            catch (Exception ex)
            {
                return BadRequest(new CreditoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpPost("Atualizar")]
        public async Task<ActionResult<BoolRetornoDTO>> Atualizar([FromBody] CreditoDTO credito)
        {
            try
            {

                var atualizarReturn  = await _creditoService.Atualizar(credito);
                if(atualizarReturn.Sucesso)
                    return Ok(new BoolRetornoDTO { sucesso = true});
                else
                    return BadRequest(new BoolRetornoDTO { sucesso = false, Erro = atualizarReturn.Erros[0] });
            }
            catch (Exception ex)
            {
                return BadRequest(new CreditoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpPost("Excluir")]
        public async Task<ActionResult<BoolRetornoDTO>> Excluir([FromBody] IdDTO excluir)
        {
            try
            {
                var excluirReturn = new BoolRetornoDTO();
                var result = await _creditoService.Excluir(excluir.Id);
                if (result.Sucesso)
                    excluirReturn.sucesso = true;
                else
                {
                    excluirReturn.Erro = result.Erros[0];
                    excluirReturn.sucesso = false;
                }
                return Ok(excluirReturn);

            }
            catch (Exception ex)
            {
                return BadRequest(new CreditoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpPost("Obter")]
        public async Task<ActionResult<CreditoRetornoDTO>> Obter([FromBody] IdDTO obter)
        {
            try
            {
                return Ok(await _creditoService.Obter(obter.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new CreditoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpGet("ObterTodos")]
        public async Task<ActionResult<RetornoListaDTO<CreditoRetornoDTO>>> ObterTodos()
        {
            try
            {
                var obterTodosReturn = new RetornoListaDTO<CreditoRetornoDTO>();
                obterTodosReturn.Dados = await _creditoService.ObterTodos();
                if (obterTodosReturn.Dados == null)
                    throw new Exception("Dados não encontrados.");
                return Ok(obterTodosReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new CreditoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }
        [HttpPost("PesquisarPorData")]
        public async Task<ActionResult<RetornoListaDTO<CreditoRetornoDTO>>> PesquisarPorData([FromBody] RangeDatasDTO rangeDatas)
        {
            try
            {
                var obterTodosReturn = new RetornoListaDTO<CreditoRetornoDTO>();
                obterTodosReturn.Dados = await _creditoService.PesquisarPorData(rangeDatas.DataInicio, rangeDatas.DataFim);
                if (obterTodosReturn.Dados == null)
                    throw new Exception("Dados não encontrados.");
                return Ok(obterTodosReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new CreditoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpPost("PesquisarPorDescricao")]
        public async Task<ActionResult<RetornoListaDTO<CreditoRetornoDTO>>> PesquisarPorDescricao([FromBody] PesquisaDescricaoDTO descricao)
        {
            try
            {
                var obterTodosReturn = new RetornoListaDTO<CreditoRetornoDTO>();
                obterTodosReturn.Dados = await _creditoService.PesquisarPorDescricao(descricao.Descricao);
                if (obterTodosReturn.Dados == null)
                    throw new Exception("Dados não encontrados.");
                return Ok(obterTodosReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new CreditoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }


    }
}
