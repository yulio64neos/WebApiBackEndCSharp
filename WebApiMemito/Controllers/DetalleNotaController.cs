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
    public class DetalleNotaController : ApiController
    {
        ClassDetalleNDAL obj = new ClassDetalleNDAL();
        // GET api/<controller>
        [HttpGet]
        public List<DetalleNota> Get()
        {
            string mensaje = "";
            return obj.ListaDetalleNota(ref mensaje);
        }
        [HttpGet]
        public DetalleNota GetById(string x)
        {
            string mensaje = "";
            return obj.Obtener(x, ref mensaje);
        }

        [HttpPost]
        public bool Post([FromBody] DetalleNotaPost detaNota)
        {
            string mensaje = "";
            return obj.RegistrarDetaNota(detaNota, ref mensaje);
        }
    }
}