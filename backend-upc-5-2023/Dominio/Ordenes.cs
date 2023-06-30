// Ignore Spelling: Ordenes

namespace backend_upc_restaurante.Dominio
{
    /// <summary>
    /// Dominio de la tabla Platos
    /// </summary>
    public class Ordenes
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        public int Platos_Id { get; set; }
        public int Cantidad { get; set; }
        public int  Mesa { get; set; }
      //  public int EstadoRegistro { get; set; }
        
    }
}
