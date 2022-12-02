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
    public class NotaController : ApiController
    {
        ClassNotaDAL obj = new ClassNotaDAL();

        [HttpGet]
        public List<Nota> Get()
        {
            return obj.ListaNota();
        }

        [HttpGet]
        public Nota GetById(string x)
        {
            return obj.Obtener(x);
        }

        [HttpPost]
        public bool Post([FromBody] Nota nota)
        {
            return obj.RegistrarNota(nota);
        }
    }
}