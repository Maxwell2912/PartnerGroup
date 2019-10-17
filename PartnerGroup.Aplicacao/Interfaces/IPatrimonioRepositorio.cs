using PartnerGroup.Dominio;
using System;
using System.Collections.Generic;

namespace PartnerGroup.Aplicacao.Interfaces
{
    public interface IPatrimonioRepositorio
    {
        List<Patrimonio> Obtenha();
        List<Patrimonio> ObtenhaPorMarca(Guid marcaId);
        Patrimonio Obtenha(Guid id);
        Patrimonio Atualize(Patrimonio patrimonio);
        Patrimonio Salve(Patrimonio patrimonio);
        bool Delete(Guid id);
    }
}
