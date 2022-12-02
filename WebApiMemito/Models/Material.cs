using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMemito.Models
{
    public class Material
    {
        public int Id_Mate { set; get; }
        public string Nombre_Mat { set; get; }
        public string Marca { set; get; }
        public string Categoria { set; get; }
        public string UnidadMedida { set; get; }
    }
}