using Desafio.BancoCarrefour.FluxoCaixa.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.BancoCarrefour.FluxoCaixa.Tests
{
    public static class GerarCredito
    {
        public static List<CreditoDTO> Registers()
        {
            var _dados = new List<CreditoDTO>
            {
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime(Convert.ToDateTime("2023-04-21T17:04:13.108372Z")),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 1",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  33.59m
              },
              new CreditoDTO {
                FormaRecebimento =  "Dinheiro",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-10T23:15:13.1094398Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 1",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  32.54m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-22T11:22:13.1094632Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico1",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  50.65m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-15T23:31:13.1094714Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 2",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  17.17m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-16T18:48:13.1094721Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 2",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  50.06m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-05T11:42:13.1094779Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico2",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  53.65m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-28T16:05:13.1094784Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 3",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  7.15m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-12T10:21:13.109479Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 4",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  40.09m
              },
              new CreditoDTO {
                FormaRecebimento =  "Dinheiro",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-27T00:29:13.1094794Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 5",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  94.98m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-10T05:39:13.10948Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 3",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  8.63m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-22T08:09:13.1094804Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 4",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  92.75m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-04T23:46:13.1094809Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico3",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  18.02m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-01T18:38:13.1094814Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 6",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  80.32m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-27T22:53:13.1094818Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 7",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  25.32m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-05T16:59:13.1094822Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 5",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  97.07m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-26T19:23:13.1094827Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico4",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  89.65m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-21T11:04:13.109483Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico5",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  45.13m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-17T13:23:13.1094836Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 6",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  75.68m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-16T08:02:13.1094841Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 7",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  15.73m
              },
              new CreditoDTO {
                FormaRecebimento =  "Dinheiro",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-23T20:54:13.1094845Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 8",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  36.74m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-15T20:03:13.1094849Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 9",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  26.49m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-17T01:39:13.1094853Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 8",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  43.97m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-29T10:21:13.1094857Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico6",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  71.54m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-01T16:52:13.1094926Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 9",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  6.51m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-23T07:47:13.109493Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico7",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  96.30m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-02T07:50:13.1094935Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 10",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  56.25m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-15T01:00:13.1094939Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 11",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  58.40m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-23T16:47:13.1094943Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico8",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  63.38m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-27T19:55:13.1094947Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico9",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  48.33m
              },
              new CreditoDTO {
                FormaRecebimento =  "Dinheiro",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-27T10:35:13.1094952Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 10",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  79.47m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-14T14:36:13.1094956Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 12",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  35.94m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-01T13:32:13.109496Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico10",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  99.32m
              },
              new CreditoDTO {
                FormaRecebimento =  "Dinheiro",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-15T10:30:13.1094964Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico11",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  33.43m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-22T16:17:13.109497Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico12",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  55.64m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-14T21:06:13.1094974Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 11",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  32.85m
              },
              new CreditoDTO {
                FormaRecebimento =  "Dinheiro",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-03T18:43:13.1094978Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 13",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  27.26m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-30T03:45:13.1094982Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 14",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  2.83m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-20T18:42:13.1094986Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico13",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  43.42m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-25T22:07:13.1094991Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico14",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  38.57m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-04T06:52:13.1094996Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 15",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  23.84m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-11T03:03:13.1095Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 16",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  82.43m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-21T05:26:13.1095004Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 17",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  3.48m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-02T09:09:13.1095008Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 12",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  63.70m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-16T12:39:13.1095012Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico15",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  42.31m
              },
              new CreditoDTO {
                FormaRecebimento =  "Dinheiro",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-20T11:18:13.1095017Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 18",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  46.29m
              },
              new CreditoDTO {
                FormaRecebimento =  "Pix",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-05T00:02:13.109502Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico16",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  61.28m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-30T18:32:13.1095025Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Servico17",
                CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                Valor =  54.87m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Crédito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-13T20:22:13.1095028Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 19",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  98.66m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-03T21:14:13.1095032Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Locacao 20",
                CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                Valor =  15.01m
              },
              new CreditoDTO {
                FormaRecebimento =  "Cartão Débito",
                Id = null,
                DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-19T14:13:13.1095037Z"),
                UsuarioLancamento =  "ADM",
                Descricao =  "Venda 13",
                CategoriaId = "0e6f1047-ca4d-4aea-9dec-a2f968ce370a",
                Valor =  65.31m
              }
            };
            return _dados;
        }
    }
}
