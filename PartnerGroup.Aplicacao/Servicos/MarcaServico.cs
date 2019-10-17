using PartnerGroup.Aplicacao.Interfaces;
using PartnerGroup.Dominio;
using System;
using System.Collections.Generic;

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
            try
            {
                if (_marcaRepositorio.MarcaCadastrada(marca))
                    throw new Exception("Marca já cadastrada");
                return _marcaRepositorio.Atualize(marca);
            }
            catch (Exception)
            {
                throw;
            }
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
            try
            {
                if (_marcaRepositorio.MarcaCadastrada(marca))
                    throw new Exception("Marca já cadastrada");
                return _marcaRepositorio.Salve(marca);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
