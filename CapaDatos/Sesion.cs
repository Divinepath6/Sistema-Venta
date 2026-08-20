using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos {
    public class CD_Sesion {
       public CD_Sesion() {

       }
        public bool Intento(String MacAddress) {
            Sesion  sesion = new Sesion();
            sesion.mac = MacAddress;
            using(SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {
                try {
                    SqlCommand cmd = new SqlCommand("Revisar_intento", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mac", SqlDbType.VarChar, 20).Value = MacAddress;
                    SqlParameter intentosSistemaParam = cmd.Parameters.Add("@intentos_sistema", SqlDbType.Int);
                    intentosSistemaParam.Direction = ParameterDirection.Output;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    int intentosSistema = (int)intentosSistemaParam.Value;
                    if(intentosSistema > 5) {
                        sesion.Aceptado = false;
                    }
                    else {
                        sesion.Aceptado = true;
                    }
                }
                catch(Exception ex) {
                }
            }
            return sesion.Aceptado;
        }
        public void Inicio(String MacAddress) {
            using(SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {
                try {
                    oconexion.Open();
                    string query = "UPDATE Intentos_sesion SET intentos = 0 WHERE mac = @mac";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@mac", MacAddress);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex) {
                }
            }
        }
    }
}
