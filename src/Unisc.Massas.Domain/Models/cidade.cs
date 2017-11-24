namespace Unisc.Massas.Domain.Models
{
    public class Cidade : EntityBase
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public int CodIbge { get; set; }
        public decimal? DensidadeDemo { get; set; }
        public string Populacao { get; set; }
        public string Gentilico { get; set; }
        public decimal? Area { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
