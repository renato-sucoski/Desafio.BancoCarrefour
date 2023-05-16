using Desafio.BancoCarrefour.FluxoCaixa.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.BancoCarrefour.FluxoCaixa.Tests
{
    public class GerarDebito
    {
        public static List<DebitoDTO> Registers()
        {
            var _dados = new List<DebitoDTO>
            {
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-07T18:05:38.5296657Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 1",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 94.87m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-25T10:36:38.5306609Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 2",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 82.83m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-23T03:46:38.5306848Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico1",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 59.33m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-09T15:48:38.530686Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 3",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 9.17m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-16T13:46:38.5306865Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico2",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 46.00m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-03T01:44:38.5306921Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico3",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 15.82m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-07T13:10:38.5306928Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico4",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 28.60m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-18T23:11:38.5306932Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 4",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 15.11m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-08T16:59:38.5306936Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Locacao 1",
                    CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                    Valor = 35.74m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-09T12:39:38.5306946Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Locacao 2",
                    CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                    Valor = 35.20m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-27T23:55:38.5306951Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 5",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 28.19m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-24T08:38:38.5306955Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 6",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 6.71m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-17T10:19:38.530696Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico5",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 52.82m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-15T10:36:38.5306964Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Locacao 3",
                    CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                    Valor = 28.13m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-02T11:30:38.5306968Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Locacao 4",
                    CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                    Valor = 74.81m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-22T10:16:38.5306972Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico6",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 18.95m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-23T01:22:38.5306976Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 7",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 41.36m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-11T15:43:38.5306982Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Locacao 5",
                    CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                    Valor = 31.61m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-03T01:38:38.5306986Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 8",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 75.16m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-29T03:04:38.530699Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 9",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 9.34m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-09T14:20:38.5306994Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico7",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 72.46m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-02T21:55:38.5306999Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Locacao 6",
                    CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                    Valor = 62.62m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-24T03:01:38.5307003Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Locacao 7",
                    CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                    Valor = 16.49m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-16T13:58:38.5307061Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 10",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 30.32m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-19T10:18:38.5307066Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico8",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 62.26m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-30T02:00:38.530707Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico9",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 64.84m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-03T14:22:38.5307075Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico10",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 58.49m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-27T13:29:38.5307079Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico11",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 47.03m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-17T13:41:38.5307083Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico12",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 67.46m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-08T11:53:38.5307087Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico13",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 96.44m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-26T19:58:38.5307091Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Locacao 8",
                    CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                    Valor = 48.69m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-03T20:14:38.5307096Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico14",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 9.03m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-28T11:11:38.53071Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico15",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 28.92m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-26T01:29:38.5307106Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 11",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 9.19m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-17T13:08:38.530711Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 12",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 66.88m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-15T10:29:38.5307114Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico16",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 4.86m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-22T22:16:38.5307118Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 13",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 76.98m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-25T20:44:38.5307122Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico17",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 98.38m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-10T17:15:38.5307126Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Locacao 9",
                    CategoriaId = "3eec3f3d-e23a-404d-bf0a-aecd069ceb9f",
                    Valor = 32.48m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-24T02:05:38.5307131Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 14",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 43.33m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-12T05:25:38.5307135Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico18",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 28.47m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-14T23:20:38.5307139Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico19",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 39.99m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-07T13:56:38.5307143Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 15",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 10.60m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-14T18:28:38.5307148Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 16",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 55.13m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Credito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-15T00:05:38.5307152Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 17",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 66.63m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-03T22:48:38.5307157Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico20",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 74.40m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-20T15:36:38.530716Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico21",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 71.57m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Dinheiro",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-12T02:04:38.5307165Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico22",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 79.74m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Cartão Debito",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-04-16T15:58:38.5307169Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Compra 18",
                    CategoriaId = "389975e6-b700-40a8-9db5-d466a0a3c10a",
                    Valor = 21.88m
                  },
                  new DebitoDTO{
                    FormaPagamento = "Pix",
                    Id = null,
                    DataHoraLancamentoUTC =  Convert.ToDateTime("2023-05-04T05:02:38.5307172Z"),
                    UsuarioLancamento = "ADM",
                    Descricao = "Servico23",
                    CategoriaId = "5a42c095-7e73-4069-855a-c80c05b925b0",
                    Valor = 31.71m
                  }
            };
            return _dados;
        }
    }
}
