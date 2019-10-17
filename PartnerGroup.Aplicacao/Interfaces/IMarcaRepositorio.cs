using PartnerGroup.Dominio;
using System;
using System.Collections.Generic;

namespace PartnerGroup.Aplicacao.Interfaces
{
    public interface IMarcaRepositorio
    {
        List<Marca> Obtenha();
        Marca Obtenha(Guid id);
        Marca Atualize(Marca marca);
        Marca Salve(Marca marca);
        bool Delete(Guid id);
        bool MarcaCadastrada(Marca marca);
    }
}
