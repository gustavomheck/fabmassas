namespace Unisc.Massas.Domain.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        bool Filtrar(object obj, string propertyName, string value);
    }
}
