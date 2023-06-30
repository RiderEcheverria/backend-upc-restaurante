
using backend_upc_restaurante.Connection;
using backend_upc_restaurante.Dominio;
using backend_upc_restaurante.Servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_restaurante.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="Ordenes"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [EnableCors("DevelopmentCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
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
        public OrdenesController(IConfiguration configuration)
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
                var result = OrdenesServicios.Get<Ordenes>();
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
        [Route("GetCOrdenessById")]
        public IActionResult GetOrdenesById([FromQuery] int id)
        {
            try
            {
                var result = OrdenesServicios.GetById<Ordenes>(id);
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
        [Route("AddOrdenes")]
        public IActionResult Insert(Ordenes ordenes)
        {
            try
            {
                var result = OrdenesServicios.Insert(ordenes);
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
        /// <param name="ordenes">The platos.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateOrdenes")]
        public IActionResult Update(Ordenes ordenes)
        {
            try
            {
                var result = OrdenesServicios.Update(ordenes);
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
        [Route("DeleteOrdenes")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = OrdenesServicios.Delete(id);
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
