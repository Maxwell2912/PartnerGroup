using System;
using System.Collections.Generic;
using PartnerGroup.Aplicacao.Interfaces;
using PartnerGroup.Dominio;

namespace PartnerGroup.Aplicacao.Servicos
{
    public class PatrimonioServico : IPatrimonioServico
    {
        private readonly IPatrimonioRepositorio _patrimonioRepositorio;

        public PatrimonioServico(IPatrimonioRepositorio patrimonioRepositorio)
        {
            _patrimonioRepositorio = patrimonioRepositorio;
        }

        public Patrimonio Atualize(Patrimonio patrimonio)
        {
            return _patrimonioRepositorio.Atualize(patrimonio);
        }

        public bool Delete(Guid id)
        {
            return _patrimonioRepositorio.Delete(id);
        }

        public List<Patrimonio> Obtenha()
        {
            return _patrimonioRepositorio.Obtenha();
        }

        public Patrimonio Obtenha(Guid id)
        {
            return _patrimonioRepositorio.Obtenha(id);
        }

        public List<Patrimonio> ObtenhaPorMarca(Guid marcaId)
        {
            return _patrimonioRepositorio.ObtenhaPorMarca(marcaId);
        }

        public Patrimonio Salve(Patrimonio patrimonio)
        {
            return _patrimonioRepositorio.Salve(patrimonio);
        }
    }
}
