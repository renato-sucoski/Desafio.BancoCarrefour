using Desafio.BancoCarrefour.FluxoCaixa.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;


namespace Desafio.BancoCarrefour.FluxoCaixa.DTOs
{
    public class BaseFluxoDTO
    {
        public string Id { get; set; }

        public DateTime DataHoraLancamentoUTC { get; set; }

        public string UsuarioLancamento { get; set; }

        public string Descricao { get; set; }
        public string CategoriaId { get; set; }
        public decimal Valor { get; set; }
      

    }
}
