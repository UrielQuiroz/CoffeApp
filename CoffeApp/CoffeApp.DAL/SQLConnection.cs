using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace CoffeApp.DAL.MsSQL
{
    public class SQLConnection
    {
        private readonly SqlConnection conexion;
        public string Error { get; private set; }

        public SQLConnection()
        {
            conexion = new SqlConnection(@"Data Source=UQUIROZ\SQLEXPRESS;Initial Catalog=CoffeAppDB;Integrated Security=True");
            Conectar();
        }

        private bool Conectar()
        {
            try
            {
                conexion.Open();
                Error = "";
                return true;
            }
            catch (SqlException ex)
            {
                Error = ex.Message;
                return false;
                throw;
            }
        }


        /// <summary>
        /// Ejectuta un comando SQL sobre la base de datos(Insert, Update, Delete)
        /// </summary>
        /// <param name="command">Comando SQL a ejecutar</param>
        /// <returns>Regresa el numero de filas afectadas, -1 cuando ha ocurrido un error</returns>
        public int Comando(string command)
        {
            try
            {
                Debug.Print($" ====>{command}");
                SqlCommand cmd = new SqlCommand(command, conexion);
                int r = cmd.ExecuteNonQuery();
                Error = "";
                return r;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }



        /// <summary>
        /// Ejecuta una consulta SQL sobre la base de datos, (Select)
        /// </summary>
        /// <param name="consulta">Consulta SQL</param>
        /// <returns>Registros resultantes de la consulta</returns>
        public SqlDataReader Consulta(string consulta)
        {
            try
            {
                Debug.Print($" ====>{consulta}");
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                SqlDataReader dataReader = cmd.ExecuteReader();
                Error = "";
                return dataReader;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        ~SQLConnection()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                }
            }
        }
    }
}
