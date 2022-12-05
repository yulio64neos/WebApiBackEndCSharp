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
    public class ObraController : ApiController
    {
        ClassObraDAL obj = new ClassObraDAL();

        [HttpGet]
        public List<Obra> Get()
        {
            string mensaje = "";
            return obj.ListaObra(ref mensaje);
        }

        [HttpGet]
        public Obra GetById(string x)
        {
            string mensaje = "";
            return obj.Obtener(x, ref mensaje);
        }

        [HttpPost]
        public bool Post([FromBody] Obra obra)
        {
            string mensaje = "";
            return obj.RegistrarObra(obra, ref mensaje);
        }
    }
}