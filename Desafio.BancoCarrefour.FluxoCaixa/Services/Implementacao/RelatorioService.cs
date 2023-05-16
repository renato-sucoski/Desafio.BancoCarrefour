using Desafio.BancoCarrefour.FluxoCaixa.DTOs;
using Desafio.BancoCarrefour.FluxoCaixa.DTOs.Relatorio;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.FluxoCaixa.Services.Implementacao
{
    public class RelatorioService : IBaseRelatorioService
    {
        private readonly ICreditoService _creditoService;
        private readonly IDebitoService _debitoService;

        public RelatorioService(ICreditoService creditoService, IDebitoService debitoService)
        {
            _creditoService = creditoService;
            _debitoService = debitoService;
        }
        public async Task<RelatorioConsolidadoDiarioCategoriaDTO> RelatorioConsolidadoDiarioCategoria(string dataInicio, string dataFim)
        {
            try
            {
                var creditos = await _creditoService.PesquisarPorData(dataInicio, dataFim);
                var debitos = await _debitoService.PesquisarPorData(dataInicio, dataFim);
                var datasOperacoes = new List<DateTime>();

                if (creditos != null && creditos.Count > 0)
                    datasOperacoes = creditos.GroupBy(x => x.DataHoraLancamentoUTC.ToLocalTime().Date).Select(x => x.Key).ToList();

                if (debitos != null && debitos.Count > 0)
                    datasOperacoes.AddRange(debitos.GroupBy(x => x.DataHoraLancamentoUTC.ToLocalTime().Date).Select(x => x.Key).ToList());

                if (datasOperacoes.Count == 0)
                    throw new Exception("Dados não encontrados para o range de datas.");


                datasOperacoes = datasOperacoes.GroupBy(x => x).Select(x => x.Key).ToList();
                var datas = new List<DataConsolidadoDTO<ValorCategoriaCreditoDTO, ValorCategoriaDebitoDTO>>();
                foreach (var item in datasOperacoes.OrderBy(x => x))
                {
                    var data = new DataConsolidadoDTO<ValorCategoriaCreditoDTO, ValorCategoriaDebitoDTO> { Data = item.ToString("dd/MM/yyyy") };
                    var retornoCred = creditos.
                        Where(x => x.DataHoraLancamentoUTC.ToLocalTime().Date == item.Date)
                        .GroupBy(x => new { x.Categoria.Descricao, x.DataHoraLancamentoUTC.ToLocalTime().Date })
                        .Select(x => new ValorCategoriaCreditoDTO { Categoria = x.Key.Descricao, ValorTotal = x.Sum(y => y.Valor) })
                        .ToList();
                    if (retornoCred != null)
                    {
                        data.TotalCredito = retornoCred.Sum(x => x.ValorTotal);
                        data.DadosCredito = new List<ValorCategoriaCreditoDTO>();
                        data.DadosCredito.AddRange(retornoCred);
                    }
                    var retornoDeb = debitos.
                        Where(x => x.DataHoraLancamentoUTC.ToLocalTime().Date == item.Date)
                        .GroupBy(x => new { x.Categoria.Descricao, x.DataHoraLancamentoUTC.ToLocalTime().Date })
                        .Select(x => new ValorCategoriaDebitoDTO { Categoria = x.Key.Descricao, ValorTotal = x.Sum(y => y.Valor) })
                        .ToList();
                    if (retornoDeb != null)
                    {
                        data.TotalDebito = retornoDeb.Sum(x => x.ValorTotal);
                        data.DadosDebito = new List<ValorCategoriaDebitoDTO>();
                        data.DadosDebito.AddRange(retornoDeb);
                    }

                    data.ResultadoDia = data.TotalCredito - data.TotalDebito;

                    datas.Add(data);
                }
                
                var reportReturn = new RelatorioConsolidadoDiarioCategoriaDTO { Data = datas, Erro = null, Sucesso = true };
                reportReturn.TotalCreditoPeriodo = reportReturn.Data.Sum(x => x.TotalCredito);
                reportReturn.TotalDebitoPeriodo = reportReturn.Data.Sum(x => x.TotalDebito);
                reportReturn.ResultadoPeriodo = reportReturn.TotalCreditoPeriodo - reportReturn.TotalDebitoPeriodo;

                var json = JsonConvert.SerializeObject(reportReturn);
                return reportReturn;

            }
            catch (Exception ex)
            {
                var reportReturn = new RelatorioConsolidadoDiarioCategoriaDTO { Data = null, Erro = new ErrorBaseDTO { Codigo = "030", Mensagem = ex.Message }, Sucesso = false };
                return reportReturn;

            }

        }

        public async Task<RelatorioConsolidadoDiarioFormaPagamentoDTO> RelatorioConsolidadoDiarioFormaPagamento(string dataInicio, string dataFim)
        {
            try
            {
                var creditos = await _creditoService.PesquisarPorData(dataInicio, dataFim);
                var debitos = await _debitoService.PesquisarPorData(dataInicio, dataFim);
                var datasOperacoes = new List<DateTime>();

                if (creditos != null && creditos.Count > 0)
                    datasOperacoes = creditos.GroupBy(x => x.DataHoraLancamentoUTC.ToLocalTime().Date).Select(x => x.Key).ToList();

                if (debitos != null && debitos.Count > 0)
                    datasOperacoes.AddRange(debitos.GroupBy(x => x.DataHoraLancamentoUTC.ToLocalTime().Date).Select(x => x.Key).ToList());

                if (datasOperacoes.Count == 0)
                    throw new Exception("Dados não encontrados para o range de datas.");


                datasOperacoes = datasOperacoes.GroupBy(x => x).Select(x => x.Key).ToList();
                var datas = new List<DataConsolidadoDTO<ValorFormaPagamentoCreditoDTO, ValorFormaPagamentoDebitoDTO>>();
                foreach (var item in datasOperacoes.OrderBy(x => x))
                {
                    var data = new DataConsolidadoDTO<ValorFormaPagamentoCreditoDTO, ValorFormaPagamentoDebitoDTO> { Data = item.ToString("dd/MM/yyyy") };
                    var retornoCred = creditos.
                        Where(x => x.DataHoraLancamentoUTC.ToLocalTime().Date == item.Date)
                        .GroupBy(x => new { x.FormaRecebimento, x.DataHoraLancamentoUTC.ToLocalTime().Date })
                        .Select(x => new ValorFormaPagamentoCreditoDTO { FormaPagamento = x.Key.FormaRecebimento, ValorTotal = x.Sum(y => y.Valor) })
                        .ToList();
                    if (retornoCred != null)
                    {
                        data.TotalCredito = retornoCred.Sum(x => x.ValorTotal);
                        data.DadosCredito = new List<ValorFormaPagamentoCreditoDTO>();
                        data.DadosCredito.AddRange(retornoCred);
                    }
                    var retornoDeb = debitos.
                        Where(x => x.DataHoraLancamentoUTC.ToLocalTime().Date == item.Date)
                        .GroupBy(x => new { x.FormaPagamento, x.DataHoraLancamentoUTC.ToLocalTime().Date })
                        .Select(x => new ValorFormaPagamentoDebitoDTO { FormaPagamento = x.Key.FormaPagamento, ValorTotal = x.Sum(y => y.Valor) })
                        .ToList();
                    if (retornoDeb != null)
                    {
                        data.TotalDebito = retornoDeb.Sum(x => x.ValorTotal);
                        data.DadosDebito = new List<ValorFormaPagamentoDebitoDTO>();
                        data.DadosDebito.AddRange(retornoDeb);
                    }

                    data.ResultadoDia = data.TotalCredito - data.TotalDebito;

                    datas.Add(data);
                }

                var reportReturn = new RelatorioConsolidadoDiarioFormaPagamentoDTO { Data = datas, Erro = null, Sucesso = true };
                reportReturn.TotalCreditoPeriodo = reportReturn.Data.Sum(x => x.TotalCredito);
                reportReturn.TotalDebitoPeriodo = reportReturn.Data.Sum(x => x.TotalDebito);
                reportReturn.ResultadoPeriodo = reportReturn.TotalCreditoPeriodo - reportReturn.TotalDebitoPeriodo;

                var json = JsonConvert.SerializeObject(reportReturn);
                return reportReturn;

            }
            catch (Exception ex)
            {
                var reportReturn = new RelatorioConsolidadoDiarioFormaPagamentoDTO{ Data = null, Erro = new ErrorBaseDTO { Codigo = "040", Mensagem = ex.Message }, Sucesso = false };
                return reportReturn;

            }

        }


    }


}
