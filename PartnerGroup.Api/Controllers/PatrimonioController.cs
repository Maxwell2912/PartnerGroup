using Microsoft.AspNetCore.Mvc;
using PartnerGroup.Aplicacao.Interfaces;
using PartnerGroup.Dominio;
using System;
using System.Collections.Generic;

namespace PartnerGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimonioController : ControllerBase
    {
        private readonly IPatrimonioServico _patrimonioServico;

        public PatrimonioController(IPatrimonioServico patrimonioServico)
        {
            _patrimonioServico = patrimonioServico;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patrimonio>> Get()
        {
            return _patrimonioServico.Obtenha();
        }

        [HttpGet("{id}")]
        public ActionResult<Patrimonio> Get(Guid id)
        {
            return _patrimonioServico.Obtenha(id);
        }

        [HttpPost]
        public void Post([FromBody] Patrimonio patrimonio)
        {
            _patrimonioServico.Salve(patrimonio);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Patrimonio patrimonio)
        {
            _patrimonioServico.Atualize(patrimonio);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _patrimonioServico.Delete(id);
        }
    }
}
