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
            string mensaje = "";
            return obj.ListaNota(ref mensaje);
        }

        [HttpGet]
        public Nota GetById(string x)
        {
            string mensaje = "";
            return obj.Obtener(x, ref mensaje);
        }

        [HttpGet]
        public List<Nota> GetNotaObra(string x)
        {
            string mensaje = "";
            return obj.NotaObra(x, ref mensaje);
        }

        [HttpGet]
        public List<Nota> GetFecha(string x, string x2, string x3)
        {
            string mensaje = "";
            return obj.NotaObraFecha(x, x2, x3, ref mensaje);
        }


        [HttpPost]
        public bool Post([FromBody] Nota nota)
        {
            string mensje = "";
            return obj.RegistrarNota(nota, ref mensje);
        }
    }
}