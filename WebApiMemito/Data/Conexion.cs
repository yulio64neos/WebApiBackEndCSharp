using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApiMemito.Data
{
    public class Conexion
    {
        public static string CadCon = "Data Source=.;Initial Catalog=PagosObras2022;Integrated Security=True";

        //public Conexion()
        //{
        //    CadCon = ConfigurationManager.ConnectionStrings["Obra"].ConnectionString;
        //}
    }
}