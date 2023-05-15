using EFCore_BulkExtensionsLab.Aplicacao;
using EFCore_BulkExtensionsLab.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore_BulkExtensionsLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroController : ControllerBase
    {
        private IServiceProvider serviceProvider { get; set; }
        private RegistroAplicacao _App { get; set; }

        public RegistroController(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
            _App = new RegistroAplicacao(serviceProvider);
        }


        [HttpGet(Name = "SalvarAddRange")]
        public async Task<ActionResult<Retorno>> SalvarAddRange([FromQuery] long QuantidadeRegistros = 500000)
        {
            try
            {
                return await _App.SalvarAddRange(QuantidadeRegistros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
