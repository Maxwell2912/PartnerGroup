using PartnerGroup.Dominio;
using System;
using System.Collections.Generic;

namespace PartnerGroup.Aplicacao.Interfaces
{
    public interface IPatrimonioServico
    {
        List<Patrimonio> Obtenha();
        Patrimonio Obtenha(Guid id);
        Patrimonio Atualize(Patrimonio patrimonio);
        Patrimonio Salve(Patrimonio patrimonio);
        bool Delete(Guid id);
    }
}
