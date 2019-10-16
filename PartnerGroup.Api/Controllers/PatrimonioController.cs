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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Patrimonio>> Get()
        {
            return _patrimonioServico.Obtenha();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Patrimonio> Get(Guid id)
        {
            return _patrimonioServico.Obtenha(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Patrimonio patrimonio)
        {
            _patrimonioServico.Salve(patrimonio);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Patrimonio patrimonio)
        {
            _patrimonioServico.Atualize(patrimonio);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _patrimonioServico.Delete(id);
        }
    }
}
