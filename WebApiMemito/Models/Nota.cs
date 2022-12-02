using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMemito.Models
{
    public class Nota
    {
        public int id_Nota { set; get; }
        public DateTime Fecha { set; get; }
        public string Extra { set; get; }
    }
}