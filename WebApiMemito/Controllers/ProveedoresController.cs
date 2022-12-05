using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiMemito.Data;
using WebApiMemito.Models;

namespace WebApiMemito.Controllers
{
    public class ProveedoresController : ApiController
    {
        ClassProveedorDAL obj = new ClassProveedorDAL();

        [HttpGet]
        public List<Proveedor> Get()
        {
            string mensaje = "";
            return obj.ListaProveedor(ref mensaje);
        }

        [HttpGet]
        public Proveedor GetById(string x)
        {
            string mensaje = "";
            return obj.Obtener(x, ref mensaje);
        }

        [HttpPost]
        public bool Post([FromBody] Proveedor obra)
        {
            string mensaje = "";
            return obj.RegistrarProveedor(obra, ref mensaje);
        }
    }
}