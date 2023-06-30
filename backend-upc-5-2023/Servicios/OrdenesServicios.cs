
using backend_upc_restaurante.Connection;
using backend_upc_restaurante.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_restaurante.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="Ordenes"/>
    /// </summary>
    public static class OrdenesServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<T> Get<T>()
        {
            const string sql = "SELECT * FROM ORDENES WHERE ESTADO_REGISTRO = 1";

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
            const string sql = "SELECT * FROM ORDENES WHERE ID = @Id AND ESTADO_REGISTRO = 1";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Inserts the specified platos.
        /// </summary>
        /// <param name="ordenes">The platos.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(Ordenes ordenes)
        {           
            const string sql = "INSERT INTO [ORDENES]([PLATOS_ID], [CANTIDAD], [MESA]) VALUES (@Platos_Id, @Cantidad, @Mesa) ";
            var parameters = new DynamicParameters();

            parameters.Add("Platos_Id", ordenes.Platos_Id, DbType.Int64);
            parameters.Add("Cantidad", ordenes.Cantidad, DbType.Int64);
            parameters.Add("Mesa", ordenes.Mesa, DbType.Int64);
            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Updates the specified platos.
        /// </summary>
        /// <param name="ordenes">The platos.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Update(Ordenes ordenes)
        {
            const string sql = "UPDATE ORDENES SET PLATOS_ID = @Platos_Id, CANTIDAD = @Cantidad , MESA = @mesa WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", ordenes.Id, DbType.Int64);
            parameters.Add("PLATOS_ID", ordenes.Platos_Id, DbType.Int64);
            parameters.Add("CANTIDAD", ordenes.Cantidad, DbType.Int64);
            parameters.Add("MESA", ordenes.Mesa, DbType.Int64);
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
            const string sql = "UPDATE ORDENES SET ESTADO_REGISTRO = 0 WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }
    }
}

