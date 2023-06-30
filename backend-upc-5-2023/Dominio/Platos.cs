// Ignore Spelling: Platos

namespace backend_upc_restaurante.Dominio
{
    /// <summary>
    /// Dominio de la tabla Platos
    /// </summary>
    public class Platos
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre { get; set; }
        /// <summary>
        /// Gets or sets the Precio.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public decimal Precio { get; set; }


       // public int EstadoRegistro { get; set; }
    }
}
