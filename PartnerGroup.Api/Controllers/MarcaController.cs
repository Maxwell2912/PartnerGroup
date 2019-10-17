using Microsoft.AspNetCore.Mvc;
using PartnerGroup.Aplicacao.Interfaces;
using PartnerGroup.Dominio;
using System;
using System.Collections.Generic;

namespace PartnerGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaServico _marcaServico;
        private readonly IPatrimonioServico _patrimonioServico;

        public MarcaController(IMarcaServico marcaServico, IPatrimonioServico patrimonioServico)
        {
            _marcaServico = marcaServico;
            _patrimonioServico = patrimonioServico;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Marca>> Get()
        {
            return _marcaServico.Obtenha();
        }

        [HttpGet("{id}")]
        public ActionResult<Marca> Get(Guid id)
        {
            return _marcaServico.Obtenha(id);
        }

        [HttpGet("{id}/Patrimonios")]
        public ActionResult<IEnumerable<Patrimonio>> GetPatrimonios(Guid id)
        {
            return _patrimonioServico.ObtenhaPorMarca(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Marca value)
        {
            try
            {
                _marcaServico.Salve(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Marca value)
        {
            try
            {
                _marcaServico.Atualize(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _marcaServico.Delete(id);
        }
    }
}
