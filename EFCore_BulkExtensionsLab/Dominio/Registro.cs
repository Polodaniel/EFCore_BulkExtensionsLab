using System.ComponentModel.DataAnnotations;

namespace EFCore_BulkExtensionsLab.Dominio
{
    public class Registro
    {
        public Registro()
        {
            DataRegistro = DateTime.Now;
            SubRegistros = new List<SubRegistro>(0);
        }

        public Registro(long contador) : this()
        {
            NomeRegistro = $"Registro {contador}";

            for (int i = 0; i < 3; i++)
                SubRegistros.Add(new SubRegistro(contador));
        }

        [Key]
        public long Id { get; set; }
        
        public string NomeRegistro { get; set; }
        
        public DateTime DataRegistro { get; set; }

        public List<SubRegistro> SubRegistros { get; set; }
    }
}
