

using backend_upc_restaurante.Connection;
using backend_upc_restaurante.Dominio;
using backend_upc_restaurante.Servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_restaurante.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="Platos"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [EnableCors("DevelopmentCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatosController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public PlatosController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = PlatosServicios.Get<Platos>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets the categoria by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCPlatosById")]
        public IActionResult GetPlatosById([FromQuery] int id)
        {
            try
            {
                var result = PlatosServicios.GetById<Platos>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Adds the specified platos.
        /// </summary>
        /// <param name="platos">The platos.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPlatos")]
        public IActionResult Insert(Platos platos)
        {
            try
            {
                var result = PlatosServicios.Insert(platos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates the specified platos.
        /// </summary>
        /// <param name="platos">The platos.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePlatos")]
        public IActionResult Update(Platos platos)
        {
            try
            {
                var result = PlatosServicios.Update(platos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeletePlatos")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = PlatosServicios.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion Methods
    }
}
