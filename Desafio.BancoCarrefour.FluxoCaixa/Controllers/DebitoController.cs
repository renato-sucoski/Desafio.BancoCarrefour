using Desafio.BancoCarrefour.FluxoCaixa.DTOs.Relatorio;
using Desafio.BancoCarrefour.FluxoCaixa.DTOs;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Implementacao;

namespace Desafio.BancoCarrefour.FluxoCaixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitoController : ControllerBase
    {
        private readonly IDebitoService _debitoService;
        public DebitoController(IDebitoService debitoService)
        {
            _debitoService = debitoService;
        }
        [HttpPost("Inserir")]
        public async Task<ActionResult<DebitoRetornoDTO>> Inserir([FromBody] DebitoDTO debito)
        {
            try
            {
                return Ok(await _debitoService.Inserir(debito));
            }
            catch (Exception ex)
            {
                return BadRequest(new DebitoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpPost("Atualizar")]
        public async Task<ActionResult<DebitoRetornoDTO>> Atualizar([FromBody] DebitoDTO credito)
        {
            try
            {
                var atualizarReturn = await _debitoService.Atualizar(credito);
                if (atualizarReturn.Sucesso)
                    return Ok(new BoolRetornoDTO { sucesso = true });
                else
                    return BadRequest(new BoolRetornoDTO { sucesso = false, Erro = atualizarReturn.Erros[0] });

            }
            catch (Exception ex)
            {
                return BadRequest(new DebitoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpPost("Excluir")]
        public async Task<ActionResult<BoolRetornoDTO>> Excluir([FromBody] IdDTO excluir)
        {
            try
            {
                var excluirReturn = new BoolRetornoDTO();
                var result = await _debitoService.Excluir(excluir.Id);
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
                return BadRequest(new DebitoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpPost("Obter")]
        public async Task<ActionResult<DebitoRetornoDTO>> Obter([FromBody] IdDTO obter)
        {
            try
            {
                return Ok(await _debitoService.Obter(obter.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new DebitoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpGet("ObterTodos")]
        public async Task<ActionResult<RetornoListaDTO<DebitoRetornoDTO>>> ObterTodos()
        {
            try
            {
                var obterTodosReturn = new RetornoListaDTO<DebitoRetornoDTO>();
                obterTodosReturn.Dados = await _debitoService.ObterTodos();
                if (obterTodosReturn.Dados == null)
                    throw new Exception("Dados não encontrados.");
                return Ok(obterTodosReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new DebitoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }
        [HttpPost("PesquisarPorData")]
        public async Task<ActionResult<RetornoListaDTO<DebitoRetornoDTO>>> PesquisarPorData([FromBody] RangeDatasDTO rangeDatas)
        {
            try
            {
                var obterTodosReturn = new RetornoListaDTO<DebitoRetornoDTO>();
                obterTodosReturn.Dados = await _debitoService.PesquisarPorData(rangeDatas.DataInicio, rangeDatas.DataFim);
                if (obterTodosReturn.Dados == null)
                    throw new Exception("Dados não encontrados.");
                return Ok(obterTodosReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new DebitoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }

        [HttpPost("PesquisarPorDescricao")]
        public async Task<ActionResult<RetornoListaDTO<DebitoRetornoDTO>>> PesquisarPorDescricao([FromBody] PesquisaDescricaoDTO descricao)
        {
            try
            {
                var obterTodosReturn = new RetornoListaDTO<DebitoRetornoDTO>();
                obterTodosReturn.Dados = await _debitoService.PesquisarPorDescricao(descricao.Descricao);
                if (obterTodosReturn.Dados == null)
                    throw new Exception("Dados não encontrados.");
                return Ok(obterTodosReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new DebitoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }


    }
}
