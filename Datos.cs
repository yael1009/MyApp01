using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyApp01
{
    internal class Datos
    {
        SqlConnection conexion;
        string cadenaConexion = "server=localhost;Integrated Security=false;" +
            "User=sa;password=l12345678.;initial catalog=Agenda";

        private SqlConnection conexionOpen()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return null;
            }
        }

        private void conexionClose(SqlConnection conexion)
        {
            try { conexion.Close(); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        public bool ejecutar(string command)
        {
            try
            {
                SqlConnection conectar = conexionOpen();
                SqlCommand sqlCommand = new SqlCommand(command, conectar);
                sqlCommand.ExecuteNonQuery();
                conexionClose(conectar);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return false;
            }
        }

        public bool ejecutar(SqlCommand command)
        {
            try
            {
                SqlConnection conectar = conexionOpen();
                command.Connection = conectar;
                command.ExecuteNonQuery();
                conexionClose(conectar);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return false;
            }
        }

        public DataSet informacion(string comando)
        {
            DataSet ds = new DataSet();
            try
            {
                //conexion.Open();
                SqlConnection conectar = conexionOpen();
                SqlDataAdapter da  = new SqlDataAdapter(comando,conexion);
                //SqlCommand command = new SqlCommand(comando, conexion);
                da.Fill(ds);
                conexionClose(conectar) ;
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Error: " + ex.ToString());
                return null;
            }
        }

    }
}
