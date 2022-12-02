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
            return obj.ListaObra();
        }

        [HttpGet]
        public Obra GetById(string x)
        {
            return obj.Obtener(x);
        }

        [HttpPost]
        public bool Post([FromBody] Obra obra)
        {
            return obj.RegistrarObra(obra);
        }
    }
}