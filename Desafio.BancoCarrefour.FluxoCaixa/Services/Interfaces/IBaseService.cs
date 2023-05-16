using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces
{
    public interface IBaseService<TReq,TResp, TDao>
    {
        Task<TResp> Obter(string Id);
        Task<List<TResp>> ObterTodos();
        Task<TResp> Inserir(TReq entidade);
        Task<TResp> Atualizar(TReq entidade);
        Task<TResp> Excluir(string id);
        Task<List<TResp>> PesquisarPorData(string inicio, string fim);
        Task<List<TResp>> PesquisarPorDescricao(string descricao);
    }
}
