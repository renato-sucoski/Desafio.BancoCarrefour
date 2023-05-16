using System.Collections.Generic;

namespace Desafio.BancoCarrefour.FluxoCaixa.DTOs
{
    public class RetornoListaDTO<T>
    {
        public List<T> Dados { get; set; }
        public bool Sucesso { get; set; }
        public ErrorBaseDTO Erro { get; set; }
    }
}
