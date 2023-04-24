using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsApiexamen.Domain.Catalog;
using WsApiexamen.Models.Catalog;

namespace WsApiexamen.Controllers
{
    [ApiController]
    [Route("api/examen")]
    public class ExamenController : ControllerBase
    {
        private readonly IExamenDomain _examenDomain;
        public ExamenController(IExamenDomain examenDomain)
        {
            this._examenDomain = examenDomain;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExamenModels>>> ConsultarExamen()
        {
            var response = await _examenDomain.ConsultarExamen();
            if(response == null)
                return NotFound(response);
            else
                return  Ok(response);
        }

        [HttpPost("ConsultaExamenByParams")]
        public async Task<ActionResult<List<ExamenModels>>> ConsultaExamenByParams([FromBody] ExamenModels model)
        {
            var response = await _examenDomain.ConsultarExamen(model);
            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<bool>> AgregarExamen([FromBody] ExamenModels model)
        {
            var response = await _examenDomain.AgregarExamen(model);

            if (response.Success == true)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarExamen([FromBody] ExamenModels model)
        {
            var response = await _examenDomain.ActualizarExamen(model);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] ExamenModels model)
        {
            var response = await _examenDomain.EliminarExamen(model.IdExamen);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }


}
