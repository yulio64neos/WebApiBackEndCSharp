using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMemito.Models
{
    public class Proveedor
    {
        public int Id_Prove { set ;get; }
        public string RazonSoc { set; get; }
        public string Agente { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public string Correo { set; get; }
        public string Tipo_Material { set; get; }
    }
}