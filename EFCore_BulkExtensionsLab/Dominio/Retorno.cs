namespace EFCore_BulkExtensionsLab.Dominio
{
    public class Retorno
    {
        public Retorno()
        {
            DataHoraInicio = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss:ff");
        }

        public long QuantidadeRegistros { get; set; }
        public long QuantidadeSubRegistros { get; set; }
        public string DataHoraInicio { get; set; }
        public string DataHoraTermino { get; set; }

        public Retorno AtualizarRetorno(long QuantidadeRegistros, int QuantidadeSubRegistros) 
        {
            this.QuantidadeRegistros = QuantidadeRegistros;
            this.QuantidadeSubRegistros = QuantidadeSubRegistros;

            DataHoraTermino = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss:ff");
            return this;
        }
    }
}
