namespace Unisc.Massas.Domain.Models
{
    public class FuncaoUsuario : EntityBase
    {
        public int UsuarioId { get; set; }
        public int FuncaoId { get; set; }
        public virtual Funcao Funcao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
