using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Interfaces
{
    public interface IBaseRepositorio<T>
    {
        Task<T> Obter(string Id);
        Task<List<T>> ObterTodos();
        Task<T> Inserir(T entidade);
        Task<bool> Atualizar(T entidade);
        Task<bool> Excluir(string id);
        Task<List<T>> PesquisarPorData(DateTime inicio, DateTime fim);
        Task<List<T>> PesquisarPorDescricao(string descricao);
    }
}
