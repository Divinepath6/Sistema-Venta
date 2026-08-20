using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio {
    public class CN_Sesion {
        private string MacAddress;
        private CD_Sesion objcd_Sesion = new CD_Sesion();
        public CN_Sesion() { 
            
        }
        public Boolean sesion(String Mac) {
            return objcd_Sesion.Intento(Mac); 
        }
        public void Inicio(String Mac) {
            objcd_Sesion.Inicio(Mac);
        }
    }
}

