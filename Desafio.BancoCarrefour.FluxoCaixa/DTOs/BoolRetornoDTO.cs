using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.BancoCarrefour.FluxoCaixa.DTOs
{
    public class BoolRetornoDTO : ErrorBaseDTO
    {
        public bool sucesso { get; set; }
        public ErrorBaseDTO Erro { get; set; }
    }
}
