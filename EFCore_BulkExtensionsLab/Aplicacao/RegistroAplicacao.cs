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

                Result.QuantidadeRegistros = Registros.Count;
                Result.DataHoraTermino = DateTime.Now;
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
