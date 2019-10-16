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

        public MarcaController(IMarcaServico marcaServico)
        {
            _marcaServico = marcaServico;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Marca>> Get()
        {
            return _marcaServico.Obtenha();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Marca> Get(Guid id)
        {
            return _marcaServico.Obtenha(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Marca value)
        {
            _marcaServico.Salve(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Marca value)
        {
            _marcaServico.Atualize(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _marcaServico.Delete(id);
        }
    }
}
