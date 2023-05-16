using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.BancoCarrefour.FluxoCaixa.DTOs
{
    public class BaseFluxoRetornoDTO : BaseFluxoDTO
    {
        public CategoriaDTO Categoria { get; set; }
        public bool Sucesso {get;set;}
        public List<ErrorBaseDTO> Erros { get; set; }

    }
}
