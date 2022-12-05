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
    public class MaterialController : ApiController
    {
        ClassMaterialDAL obj = new ClassMaterialDAL();

        [HttpGet]
        public List<Material> Get()
        {
            string mensaje = "";
            return obj.ListaMaterial(ref mensaje);
        }

        [HttpGet]
        public Material GetById(string x)
        {
            string mensaje = "";
            return obj.Obtener(x, ref mensaje);
        }

        [HttpPost]
        public bool Post([FromBody] Material mate)
        {
            string mensaje = "";
            return obj.RegistrarMaterial(mate, ref mensaje);
        }
    }
}