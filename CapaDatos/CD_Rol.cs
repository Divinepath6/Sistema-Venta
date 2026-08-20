using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace CapaDatos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> list = new List<Rol>();

            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdRol, Descripcion from ROL");

                    SqlCommand cmd = new SqlCommand(query.ToString(), connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(reader["IdRol"]),
                                Descripcion = reader["Descripcion"].ToString(),

                            });

                        }
                    }
                }

                catch (Exception ex)
                {
                    list = new List<Rol> ();
                }
            }
            return list;
        }

    }
}
