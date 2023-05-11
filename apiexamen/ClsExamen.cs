using Azure;
using Microsoft.Data.SqlClient;
using System.Data;

namespace apiexamen
{
    public class ClsExamen
    {

        private readonly bool _metod;
        private readonly string _connectionString;

        public ClsExamen(bool ws,string connectionString)
        {
            if (ws)
            {
                _metod = true;
                _connectionString = connectionString;
            }
            else
            {
                _metod = false;
                _connectionString = connectionString;
            }
        }
        #region Agregar
        public async Task<ResponseODTO> AgregarExamenAsync(ExamenIDTO Examen)
        {
            ResponseODTO response = new ResponseODTO();
            if (_metod)
            {


            }
            else
            {
                ResponseCode responseCode = new ResponseCode();
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = sqlTran;
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.CommandText ="spAgregar";
                        command.Parameters.Add(new SqlParameter("@Id", Examen.Id));
                        command.Parameters.Add(new SqlParameter("Nombre", Examen.Nombre));
                        command.Parameters.Add(new SqlParameter("@Descripcion", Examen.Descripcion));
                        

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                responseCode = MapToResponseCode(reader);
                            }
                        }
                        // Commit the transaction.
                        sqlTran.Commit();
                        response.status = responseCode.Codigo != 0 ? false : true;
                        response.message = responseCode.Descripcion;

                    }
                    catch (Exception ex)
                    {
                        // Handle the exception if the transaction fails to commit.
                        Console.WriteLine(ex.Message);

                        try
                        {
                            // Attempt to roll back the transaction.
                            sqlTran.Rollback();
                            response.message = "Ocurrio un error al procesar la transaccion";
                            response.status = false;
                        }
                        catch (Exception exRollback)
                        {
                            // Throws an InvalidOperationException if the connection
                            // is closed or the transaction has already been rolled
                            // back on the server.
                            Console.WriteLine(exRollback.Message);
                        }
                    }
                }
            }

            return response;
        }
        #endregion
        #region Actualizar
        public async Task<ResponseODTO> ActualizarExamenAsync(ExamenIDTO Examen)
        {
            ResponseODTO response = new ResponseODTO();
            if (_metod)
            {


            }
            else
            {
                ResponseCode responseCode = new ResponseCode();
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = sqlTran;
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.CommandText = "spActualizar";
                        command.Parameters.Add(new SqlParameter("@Id", Examen.Id));
                        command.Parameters.Add(new SqlParameter("Nombre", Examen.Nombre));
                        command.Parameters.Add(new SqlParameter("@Descripcion", Examen.Descripcion));


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                responseCode = MapToResponseCode(reader);
                            }
                        }
                        // Commit the transaction.
                        sqlTran.Commit();
                        response.status = responseCode.Codigo != 0 ? false : true;
                        response.message = responseCode.Descripcion;

                    }
                    catch (Exception ex)
                    {
                        // Handle the exception if the transaction fails to commit.
                        Console.WriteLine(ex.Message);

                        try
                        {
                            // Attempt to roll back the transaction.
                            sqlTran.Rollback();
                            response.message = "Ocurrio un error al procesar la transaccion";
                            response.status = false;
                        }
                        catch (Exception exRollback)
                        {
                            // Throws an InvalidOperationException if the connection
                            // is closed or the transaction has already been rolled
                            // back on the server.
                            Console.WriteLine(exRollback.Message);
                        }
                    }
                }
            }

            return response;
        }
        #endregion
        #region Eliminar
        public async Task<ResponseODTO> EliminarExamenAsync(int id)
        {
            ResponseODTO response = new ResponseODTO();
            if (_metod)
            {


            }
            else
            {
                ResponseCode responseCode = new ResponseCode();
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = sqlTran;
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.CommandText = "spEliminar";
                        command.Parameters.Add(new SqlParameter("@Id", id));
                       


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                responseCode = MapToResponseCode(reader);
                            }
                        }
                        // Commit the transaction.
                        sqlTran.Commit();
                        response.status = responseCode.Codigo != 0 ? false : true;
                        response.message = responseCode.Descripcion;

                    }
                    catch (Exception ex)
                    {
                        // Handle the exception if the transaction fails to commit.
                        Console.WriteLine(ex.Message);

                        try
                        {
                            // Attempt to roll back the transaction.
                            sqlTran.Rollback();
                            response.message = "Ocurrio un error al procesar la transaccion";
                            response.status = false;
                        }
                        catch (Exception exRollback)
                        {
                            // Throws an InvalidOperationException if the connection
                            // is closed or the transaction has already been rolled
                            // back on the server.
                            Console.WriteLine(exRollback.Message);
                        }
                    }
                }
            }

            return response;
        }
        #endregion
        #region Consultar
        public async Task<List<ExamenIDTO>> ConsultarExamenAsync(ExamenIDTO Examen)
        {
         
            List<ExamenIDTO> response = new List<ExamenIDTO>();
            if (_metod)
            {


            }
            else
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
               
                    try
                    {
                        connection.Open();
                        SqlCommand command = connection.CreateCommand();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "spConsultar";
                        command.Parameters.Add(new SqlParameter("Nombre", Examen.Nombre));
                        command.Parameters.Add(new SqlParameter("@Descripcion", Examen.Descripcion));

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToExamen(reader));
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        // Handle the exception if the transaction fails to commit.
                        Console.WriteLine(ex.Message);

                    }
                }
            }

            return response;
        }
        #endregion

        private ResponseCode MapToResponseCode(SqlDataReader reader)
        {
            return new ResponseCode()
            {
                Codigo = (int)reader["Codigo"],
                Descripcion = (string)reader["Descripcion"]
            };
        }
        private ExamenIDTO MapToExamen(SqlDataReader reader)
        {
            return new ExamenIDTO()
            {
                 Id = (int)reader["idExamen"],
                 Nombre = (string)reader["Nombre"],
                Descripcion = (string)reader["Descripcion"],
            };
        }

    }
}