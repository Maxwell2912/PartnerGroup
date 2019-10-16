using System;

namespace PartnerGroup.Dominio
{
    public class Patrimonio
    {
        public string Nome { get; set; }
        public Guid MarcaId { get; set; }
        public string Descricao { get; set; }
        public long NumeroTombo { get; set; }
        public Guid Id { get; set; }
    }
}
