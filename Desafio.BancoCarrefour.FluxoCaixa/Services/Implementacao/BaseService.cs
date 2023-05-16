using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Desafio.BancoCarrefour.FluxoCaixa.DAOs;
using Desafio.BancoCarrefour.FluxoCaixa.Services.Interfaces;
using Desafio.BancoCarrefour.FluxoCaixa.Repositorios.Interfaces;
using System.ComponentModel.DataAnnotations;
using Desafio.BancoCarrefour.FluxoCaixa.DTOs;
using Desafio.BancoCarrefour.FluxoCaixa.Helpers;
using System.Globalization;

namespace Desafio.BancoCarrefour.FluxoCaixa.Services.Implementacao
{
    public class BaseService<TReq, TResp, TDao> : IBaseService<TReq, TResp, TDao> where TReq : BaseFluxoDTO where TResp : BaseFluxoRetornoDTO, new() where TDao : BaseFluxoDAO, new()
    {
        private readonly IBaseRepositorio<TDao> _repositorio;

        public BaseService(IBaseRepositorio<TDao> repositorio)
        {
            _repositorio = repositorio;
        }

        private async Task<TOutput> HandleError<TOutput>(Func<Task<TOutput>> func)
            where TOutput : BaseFluxoRetornoDTO, new()

        {

            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                var response = new TOutput();
                response.Erros = new List<ErrorBaseDTO>();
                // Tratamento de erro genérico
                response.Erros.Add(new ErrorBaseDTO { Mensagem = $"Ocorreu um erro: {ex.Message}", Codigo = "001" });
                return response;
            }
        }

        private List<ErrorBaseDTO> ValidateRequiredFields(TReq entidade)
        {

            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(entidade, new ValidationContext(entidade), results, true);
            if (isValid)
            {
                return null;
            }
            else
            {
                // A entidade é inválida, você pode acessar as mensagens de erro
                // através das ValidationResult.ErrorMessage
                foreach (var result in results)
                {
                    var erros = new List<ErrorBaseDTO>();
                    var erro = new ErrorBaseDTO { Codigo = "002", Mensagem = result.ErrorMessage };
                    erros.Add(erro);
                    return erros;
                }
                return null;
            }

        }

        public async Task<TResp> Obter(string id)
        {
            return await HandleError(async () =>
            {
                var retorno = new TResp();
                retorno.Categoria = new CategoriaDTO();
                //varifica se o ID esta preenchido
                if (string.IsNullOrWhiteSpace(id))
                    throw new Exception("Id inválido.");

                //chama o repositorio para obter a informação.
                var result = await _repositorio.Obter(id);
                if (result == null)
                    return new TResp { Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "010", Mensagem = "Registro não encontrado." } }, Sucesso = false };

                //Transfere as informações do DAO para o DTO
                Clone.CopiarPropriedades(result, retorno);
                Clone.CopiarPropriedades(result.Categoria, retorno.Categoria);
                retorno.Sucesso = true;
                //Retorna a informação
                return retorno;
            });
        }

        public async Task<List<TResp>> ObterTodos()
        {
            try
            {
                
                var result = (await _repositorio.ObterTodos());
                if (result == null)
                {
                    throw new Exception("Nenhuma entidade foi encontrada.");
                }
                var retorno = new List<TResp>();
                foreach (var item in result)
                {
                    var adc = new TResp();
                    adc.Categoria = new CategoriaDTO();
                    Clone.CopiarPropriedades(item, adc);
                    Clone.CopiarPropriedades(item.Categoria, adc.Categoria);
                    retorno.Add(adc);
                }
                return retorno;
            }
            catch
            {
                var result = new List<TResp>();
                return result;
            }
        }

        public async Task<TResp> Inserir(TReq entidade)
        {
            return await HandleError<TResp>(async () =>
            {
                var erros = ValidateRequiredFields(entidade);
                if (erros != null)
                    return new TResp { Erros = erros };

                entidade.Id = Guid.NewGuid().ToString();
                TDao entidadeDAO = new TDao();
                Clone.CopiarPropriedades(entidade, entidadeDAO);
                var result = await _repositorio.Inserir(entidadeDAO);
                var retorno = new TResp();
                Clone.CopiarPropriedades(result, retorno);
                retorno.Sucesso = true;
                return retorno;
            });
        }

        public async Task<TResp> Atualizar(TReq entidade)
        {
            return await HandleError(async () =>
            {
                var retorno = new TResp();
                ValidateRequiredFields(entidade);
                TDao entidadeDAO = new TDao();
                Clone.CopiarPropriedades(entidade, entidadeDAO);
                var result = await _repositorio.Atualizar(entidadeDAO);
                if (result)
                    retorno.Sucesso = true;
                else
                {
                    retorno.Sucesso = false;
                    retorno.Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "003", Mensagem = $"Erro ao excluir entidade {typeof(TReq).Name[..^3]}" } };
                }
                return retorno;
            });
        }

        public async Task<TResp> Excluir(string id)
        {
            return await HandleError(async () =>
            {
                var retorno = new TResp();
                if (string.IsNullOrWhiteSpace(id))
                    throw new Exception("Id inválido.");
                var result = await _repositorio.Excluir(id);
                if (result)
                    retorno.Sucesso = true;
                else
                {
                    retorno.Sucesso = false;
                    retorno.Erros = new List<ErrorBaseDTO> { new ErrorBaseDTO { Codigo = "001", Mensagem = $"Erro ao excluir entidade {typeof(TReq).Name[..^3]}" } };
                }
                return retorno;

            });
        }

        public async Task<List<TResp>> PesquisarPorData(string inicio, string fim)
        {
            try
            {
                var dataInicio = FormatDate(inicio);
                var dataFim = FormatDate(fim);
                dataFim = dataFim.AddDays(1).AddMilliseconds(-1);
                var retorno = new List<TResp>();
                var result = await _repositorio.PesquisarPorData(dataInicio.ToUniversalTime(), dataFim.ToUniversalTime());
                foreach (var item in result)
                {
                    var adc = new TResp();
                    adc.Categoria = new CategoriaDTO();
                    Clone.CopiarPropriedades(item, adc);
                    Clone.CopiarPropriedades(item.Categoria, adc.Categoria);

                    retorno.Add(adc);
                }
                return retorno;
            }
            catch
            {
                var result = new List<TResp>();
                return result;
            }

        }

        public async Task<List<TResp>> PesquisarPorDescricao(string descricao)
        {
            try
            {
                var retorno = new List<TResp>();
                var result = await _repositorio.PesquisarPorDescricao(descricao);
                if(result==null || result.Count==0)
                {
                    return null;
                }
                foreach (var item in result)
                {
                    var adc = new TResp();
                    adc.Categoria = new CategoriaDTO();
                    Clone.CopiarPropriedades(item, adc);
                    Clone.CopiarPropriedades(item.Categoria, adc.Categoria);

                    retorno.Add(adc);
                }
                return retorno;
            }
            catch
            {
                
                return null;
            }

        }
        private DateTime FormatDate(string date)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(date))
                    throw new Exception("Data Inválida.");
                DateTime returnDate;
                CultureInfo cultura = new CultureInfo("pt-BR");
                var bconvert = DateTime.TryParseExact(date, "yyyy-MM-dd", cultura, DateTimeStyles.None, out returnDate);
                if (!bconvert)
                    throw new Exception("Data Inválida.");
                return returnDate;
            }
            catch
            {
                throw new Exception("Data Inválida.");
            }

        }

    }
}
