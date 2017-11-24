namespace Unisc.Massas.Domain.Models
{
    public class Local : EntityBase
    {
        public int ClienteId { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
