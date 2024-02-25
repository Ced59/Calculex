using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Initialise la classe MathController.
    /// </summary>
    /// <param name="service">Le MathService à utiliser.</param>
    [Route("api/maths")]
    [ApiController]
    public class MathCalculConstantesController(IMathCalculConstantesService service) : ControllerBase
    {
        private readonly IMathCalculConstantesService _service = service;

        /// <summary>
        /// Calcule Pi avec un nombre spécifié de décimales, jusqu'à un maximum de 25.
        /// </summary>
        /// <param name="decimals">Le nombre de décimales de Pi à calculer. La valeur maximale est de 25.</param>
        /// <response code="200">Retourne la valeur de Pi calculée</response>
        /// <response code="400">Si le nombre de décimales demandé dépasse 15</response>
        [HttpGet("pi/{decimals}")]
        [SwaggerOperation(Tags = new[] { "Mathématiques - Constantes et Nombres Spéciaux"})]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPi(int decimals)
        {
            if (decimals > 25)
            {
                return BadRequest("Le nombre maximal de décimales autorisé est de 15.");
            }

            var result = _service.CalculatePi(decimals);
            return Ok(result);
        }

    }
}
