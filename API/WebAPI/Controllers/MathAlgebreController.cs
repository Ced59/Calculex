using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Maths;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour les opérations d'algèbre, y compris la résolution d'équations et les calculs de base.
    /// </summary>
    [Route("api/maths/algebre")]
    [ApiController]
    public class MathAlgebreController : ControllerBase
    {
        private readonly IMathCalculAlgebreService _service;

        /// <summary>
        /// Constructeur pour injecter le service d'algèbre.
        /// </summary>
        /// <param name="service">Service d'algèbre à injecter.</param>
        public MathAlgebreController(IMathCalculAlgebreService service)
        {
            _service = service;
        }

        /// <summary>
        /// Résout une équation du premier degré de la forme ax + b = 0.
        /// </summary>
        /// <param name="a">Coefficient de x.</param>
        /// <param name="b">Terme constant.</param>
        /// <returns>La solution de l'équation.</returns>
        [HttpGet("equations/premier-degre")]
        [SwaggerOperation(Tags = new[] { "Mathématiques - Algèbre - Équations" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ResoudreEquationPremierDegre(double a, double b)
        {
            try
            {
                var result = _service.ResoudreEquationPremierDegre(a, b);
                return Ok(result);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest($"Entrée invalide : {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
            }
        }

        /// <summary>
        /// Calcule les racines d'une équation du second degré de la forme ax^2 + bx + c = 0.
        /// </summary>
        /// <param name="a">Coefficient de x^2.</param>
        /// <param name="b">Coefficient de x.</param>
        /// <param name="c">Terme constant.</param>
        /// <returns>Les racines de l'équation, si elles existent.</returns>
        [HttpGet("equations/second-degre")]
        [SwaggerOperation(Tags = new[] { "Mathématiques - Algèbre - Équations" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult ResoudreEquationSecondDegre(double a, double b, double c)
        {
            try
            {
                var result = _service.ResoudreEquationSecondDegre(a, b, c);
                return Ok(result);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest($"Entrée invalide : {ex.Message}");
            }
            catch (NoRealSolutionException ex)
            {
                return NotFound($"Pas de solution réelle : {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
            }
        }

        /// <summary>
        /// Calcule la racine carrée d'un nombre donné.
        /// </summary>
        /// <param name="nombre">Le nombre pour lequel calculer la racine carrée.</param>
        /// <returns>La racine carrée du nombre spécifié.</returns>
        [HttpGet("racine-carree/{nombre}")]
        [SwaggerOperation(Tags = new[] { "Mathématiques - Algèbre - Opérations de Base" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CalculerRacineCarree(double nombre)
        {
            try
            {
                var result = _service.CalculerRacineCarree(nombre);
                return Ok(result);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest($"Entrée invalide : {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
            }
        }

        /// <summary>
        /// Convertit une valeur d'une base numérique à une autre.
        /// </summary>
        /// <param name="valeur">La valeur à convertir.</param>
        /// <param name="baseOrigine">La base numérique de la valeur d'origine.</param>
        /// <param name="baseDestination">La base numérique cible pour la conversion.</param>
        /// <returns>La valeur convertie dans la base numérique cible.</returns>
        [HttpGet("conversion-base/{valeur}/{baseOrigine}/{baseDestination}")]
        [SwaggerOperation(Tags = new[] { "Mathématiques - Algèbre - Systèmes Numériques" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ConvertirBase(string valeur, int baseOrigine, int baseDestination)
        {
            try
            {
                var result = _service.ConvertirBase(valeur, baseOrigine, baseDestination);
                return Ok(result);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest($"Entrée invalide : {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
            }
        }
    }
}