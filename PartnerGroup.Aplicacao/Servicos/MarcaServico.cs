using System;
using System.Collections.Generic;
using PartnerGroup.Aplicacao.Interfaces;
using PartnerGroup.Dominio;

namespace PartnerGroup.Aplicacao.Servicos
{
    public class MarcaServico : IMarcaServico
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public MarcaServico(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }
        public Marca Atualize(Marca marca)
        {
            return _marcaRepositorio.Atualize(marca);
        }

        public bool Delete(Guid id)
        {
            return _marcaRepositorio.Delete(id);
        }

        public List<Marca> Obtenha()
        {
            return _marcaRepositorio.Obtenha();
        }

        public Marca Obtenha(Guid id)
        {
            return _marcaRepositorio.Obtenha(id);
        }

        public Marca Salve(Marca marca)
        {
            return _marcaRepositorio.Salve(marca);
        }
    }
}
