namespace EFCore_BulkExtensionsLab.Dominio
{
    public class Retorno
    {
        public Retorno()
        {
            DataHoraInicio = DateTime.Now;
        }

        public long QuantidadeRegistros { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraTermino { get; set; }
    }
}
