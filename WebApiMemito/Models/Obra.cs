using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMemito.Models
{
    public class Obra
    {
        public int id_Obra { set; get; }
        public string Nombre_Obra { set; get; }
        public string Direccion { set; get; }
        public DateTime Fecha_ini { set; get; }
        public DateTime Fecha_fin { set; get; }
        public string Dueño { set; get; }
        public string Responsable { set; get; }
        public string Tel_resp { set; get; }
        public string Correo_resp { set; get; }

    }
}