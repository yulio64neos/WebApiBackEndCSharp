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
            return obj.ListaDetalleNota();
        }
        [HttpGet]
        public DetalleNota GetById(string x)
        {
            return obj.Obtener(x);
        }

        [HttpPost]
        public bool Post([FromBody] DetalleNotaPost detaNota)
        {
            return obj.RegistrarDetaNota(detaNota);
        }
    }
}