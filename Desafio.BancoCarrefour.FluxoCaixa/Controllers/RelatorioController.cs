using Desafio.BancoCarrefour.FluxoCaixa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces;
using Desafio.BancoCarrefour.FluxoCaixa.DTOs.Relatorio;

namespace Desafio.BancoCarrefour.FluxoCaixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private IBaseRelatorioService _relatorioService;
        public RelatorioController(IBaseRelatorioService baseRelatorioService) {
         _relatorioService = baseRelatorioService;
        }
        [HttpPost("RelatorioCategoria")]
        public async Task<ActionResult<RelatorioPorCategoriaDiarioConsolidadoDTO>> RelatorioConsolidadoDiarioCategoria([FromBody] RangeDatasDTO rangeDatas)
        {
            try
            {
                return Ok(await _relatorioService.RelatorioConsolidadoDiarioCategoria(rangeDatas.DataInicio, rangeDatas.DataFim));
            }
            catch (Exception ex)
            {
                return BadRequest(new DebitoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }
        [HttpPost("RelatorioFormaPagamento")]
        public async Task<ActionResult<RelatorioConsolidadoDiarioFormaPagamentoDTO>> RelatorioFormaPagamento([FromBody] RangeDatasDTO rangeDatas)
        {
            try
            {
                return Ok(await _relatorioService.RelatorioConsolidadoDiarioFormaPagamento(rangeDatas.DataInicio, rangeDatas.DataFim));
            }
            catch (Exception ex)
            {
                return BadRequest(new DebitoRetornoDTO { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "000", Mensagem = $"Ocorreu um erro não esperado. {ex.Message}" } }, Sucesso = false });
            }
        }
    }
}
