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
            return obj.ListaMaterial();
        }

        [HttpGet]
        public Material GetById(string x)
        {
            return obj.Obtener(x);
        }

        [HttpPost]
        public bool Post([FromBody] Material mate)
        {
            return obj.RegistrarMaterial(mate);
        }
    }
}