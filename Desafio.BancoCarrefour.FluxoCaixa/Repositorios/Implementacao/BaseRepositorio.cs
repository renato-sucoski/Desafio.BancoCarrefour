using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Desafio.BancoCarrefour.FluxoCaixa.DAOs;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Implementacao
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : BaseFluxoDAO
    {
        private readonly Context _dbContext;

        public BaseRepositorio(Context dbContext)
        {
            _dbContext = dbContext;
        }
        private async Task<TOutput> HandleError<TOutput>(Func<Task<TOutput>> func)
        {

            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                // Tratamento de erro genérico
                throw new Exception($"Ocorreu um erro ao realizar a operação: {typeof(T).Name[..^3]}: {ex.Message}");
            }
        }
        public async Task<T> Obter(string id)
        {
            var retorno = await HandleError(async () =>
            {
                var result = await _dbContext.Set<T>().Where(x => x.Id == id).Include(x=>x.Categoria).FirstOrDefaultAsync();
                return result;
            });
            return retorno;
        }

        public async Task<List<T>> ObterTodos()
        {
            return await HandleError(async () => await _dbContext.Set<T>().Include(x => x.Categoria).ToListAsync());
        }

        public async Task<T> Inserir(T entidade)
        {
            return await HandleError(async () =>
            {
                entidade.Id = Guid.NewGuid().ToString();
                await _dbContext.Set<T>().AddAsync(entidade);
                await _dbContext.SaveChangesAsync();
                return entidade;
            });
        }

        public async Task<bool> Atualizar(T entidade)
        {
            return await HandleError(async () =>
            {
                var register = await Obter(entidade.Id);
                register.Descricao = entidade.Descricao;
                register.CategoriaId = entidade.CategoriaId;
                register.Valor = entidade.Valor;
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                    return true;
                return false;
            });
        }

        public async Task<bool> Excluir(string id)
        {
            return await HandleError(async () =>
            {
                var entidade = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                if (entidade == null)
                {
                    return false;
                }
                _dbContext.Set<T>().Remove(entidade);
                return await _dbContext.SaveChangesAsync() > 0;
            });
        }

        public async Task<List<T>> PesquisarPorData(DateTime inicio, DateTime fim)
        {
            return await HandleError(async () =>
            {
                return await _dbContext.Set<T>().Where(e => e.DataHoraLancamentoUTC >= inicio && e.DataHoraLancamentoUTC <= fim).Include(x => x.Categoria).ToListAsync();
            });
        }

        public async Task<List<T>> PesquisarPorDescricao(string descricao)
        {
            return await HandleError(async () => { return await _dbContext.Set<T>().Where(e => e.Descricao.Contains(descricao)).Include(x => x.Categoria).ToListAsync(); });
        }

    }
}
