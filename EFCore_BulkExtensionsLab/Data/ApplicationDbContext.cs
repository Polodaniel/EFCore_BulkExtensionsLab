using EFCore_BulkExtensionsLab.Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFCore_BulkExtensionsLab.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Registro> Registro { get; set; }
        public DbSet<SubRegistro> SubRegistro { get; set; }
    }
}
