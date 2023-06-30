
using backend_upc_restaurante.Connection;
using backend_upc_restaurante.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_restaurante.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="Platos"/>
    /// </summary>
    public static class PlatosServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<T> Get<T>()
        {
            const string sql = "SELECT * FROM PLATOS WHERE ESTADO_REGISTRO = 1";

            return DBManager.Instance.GetData<T>(sql);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static T GetById<T>(int id)
        {
            const string sql = "SELECT * FROM PLATOS WHERE ID = @Id AND ESTADO_REGISTRO = 1";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Inserts the specified platos.
        /// </summary>
        /// <param name="platos">The platos.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(Platos platos)
        {
            const string sql = "INSERT INTO PLATOS( [NOMBRE], [PRECIO]) VALUES (@Nombre, @Precio)";

            var parameters = new DynamicParameters();
           // parameters.Add("Id", platos.Id, DbType.Int64);
            parameters.Add("Nombre", platos.Nombre, DbType.String);
            parameters.Add("Precio", platos.Precio, DbType.Decimal);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Updates the specified platos.
        /// </summary>
        /// <param name="platos">The platos.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Update(Platos platos)
        {
            const string sql = "UPDATE PLATOS SET NOMBRE = @Nombre, PRECIO = @Precio WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("ID", platos.Id, DbType.Int64);
            parameters.Add("NOMBRE", platos.Nombre, DbType.String);
            parameters.Add("PRECIO", platos.Precio, DbType.Decimal);
            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Delete(int id)
        {
            const string sql = "UPDATE PLATOS SET ESTADO_REGISTRO = 0 WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }
    }
}

