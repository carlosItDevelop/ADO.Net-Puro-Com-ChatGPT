namespace Cooperchip.ADONet.WebAPI.Models
{
    public class Fornecedor : EntityBase
    {
        public Fornecedor()
        {
            Id = base.Id;
        }

        public new int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
    }
}
