using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_BulkExtensionsLab.Dominio
{
    public class SubRegistro
    {
        public SubRegistro() =>
            DataRegistro = DateTime.Now;

        public SubRegistro(long contador) : this() =>
            NomeSubRegistro = $"Registro {contador}";

        [Key]
        public long Id { get; set; }
        
        public long RegistroId { get; set; }

        public string NomeSubRegistro { get; set; }
        
        public DateTime DataRegistro { get; set; }

        [ForeignKey(nameof(RegistroId))]
        public Registro Registro { get; set; }
    }
}
