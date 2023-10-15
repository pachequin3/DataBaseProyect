using prueba1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace prueba1.Logica
{
    public class LO_Usuario
    {

        public Usuarios EncontrarUsuario(string usuario, string clave)
        {

            Usuarios objeto = new Usuarios();


            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-VN7CRBV\\MSSQLSERVER01 ; Initial Catalog=Pediatria; Integrated Security=true"))
            {

                string query = "select Nombre,Apellido,Usuario,Clave,IdRol from USUARIOS where Usuario = @pusuario and Clave = @pclave";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pusuario", usuario);
                cmd.Parameters.AddWithValue("@pclave", clave);
                cmd.CommandType = CommandType.Text;


                conexion.Open();


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        objeto = new Usuarios()
                        {
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            IdRol = (Rol)dr["IdRol"],

                        };
                    }

                }
            }
            return objeto;

        }
    }
}