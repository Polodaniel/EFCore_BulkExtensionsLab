using EFCore.BulkExtensions;
using EFCore_BulkExtensionsLab.Data;
using EFCore_BulkExtensionsLab.Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace EFCore_BulkExtensionsLab.Aplicacao
{
    public class RegistroAplicacao
    {
        private ApplicationDbContext _contexto;
        public RegistroAplicacao(IServiceProvider serviceProvider) =>
            _contexto = serviceProvider.GetService<ApplicationDbContext>();

        private List<Registro> MontarRegistros(long Quantidade) 
        {
            var Result = new List<Registro>();

            for (long contador = 0; contador < Quantidade; contador++)
                Result.Add(new Registro(contador));

            return Result;
        }

        public async Task<Retorno> SalvarAddRange(long Quantidade) 
        {
            var Result = new Retorno();

            try
            {
                var Registros = MontarRegistros(Quantidade);

                await _contexto.Registro.AddRangeAsync(Registros);
                await _contexto.SaveChangesAsync();

                var QuantidadeRegistros = Registros.Count;
                var QuantidadeSubRegistros = Registros.SelectMany(x => x.SubRegistros).Count();

                Result.AtualizarRetorno(QuantidadeRegistros, QuantidadeSubRegistros);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }

            return Result;
        }

        /// <summary>
        /// Documentação: https://github.com/borisdj/EFCore.BulkExtensions
        /// </summary>
        /// <param name="Quantidade"></param>
        /// <returns></returns>
        public async Task<Retorno> SalvarBulkExtensions(long Quantidade)
        {
            var Result = new Retorno();

            try
            {
                var Registros = MontarRegistros(Quantidade);

                await _contexto.BulkInsertAsync(Registros, b => b.IncludeGraph = true);
                await _contexto.BulkSaveChangesAsync();

                var QuantidadeRegistros = Registros.Count;
                var QuantidadeSubRegistros = Registros.SelectMany(x => x.SubRegistros).Count();

                Result.AtualizarRetorno(QuantidadeRegistros, QuantidadeSubRegistros);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }

            return Result;
        }
    }
}
