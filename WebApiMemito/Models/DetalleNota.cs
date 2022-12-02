using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMemito.Models
{
    public class DetalleNota
    {
        public int id_Detalle { set; get; }
        public int Obra { set; get; }
        public int Prove { set; get; }
        public int Material { set; get; }
        public int Nota { set; get; }
        public int Cantidad { set; get; }
        public float PrecioUnitario { set; get; }
        public string Extra { set; get; }
        public Material Mate { set; get; }
        public Nota note { set; get; }
        public Obra obra { set; get; }
        public Proveedor prove { set; get; }
    }

    public class DetalleNotaPost
    {
        public int Obra { set; get; }
        public int Prove { set; get; }
        public int Material { set; get; }
        public int Nota { set; get; }
        public int Cantidad { set; get; } 
        public float PrecioUnitario { set; get; }
        public string Extra { set; get; }
    }
}
