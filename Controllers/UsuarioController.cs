using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto_API.Models;
using Paschoalotto_API.Data;
using System.Web.Http.Cors;


namespace Paschoalotto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioData data = new UsuarioData();

        [HttpGet]
        public bool login([FromQuery]string usuario,[FromQuery]string senha)
        {
            return data.login(usuario,senha);            
        }

        [HttpGet]
        public ActionResult<List<UsuarioModel>> getAll([FromQuery]string request)
        {
            return data.getAll();            
        }

        //GET api/usuario/nome
        [HttpGet("{user}")]
        public ActionResult<UsuarioModel> Get(string user)
        {
            return data.hasAccountUser(user);
        }

        // POST api/account
        [HttpPost]
        public ActionResult<List<UsuarioModel>> GetAll([FromQuery]string request)
        {
            return data.getAll(); 
        }

        // PUT api/account/5
        [HttpPut("{user}")]
        public void Put(string user,[FromBody] UsuarioModel usuario)
        {
            data.updateUser(user,usuario);
        }

        // DELETE api/account/5
        [HttpDelete]
        public void Delete([FromBody] UsuarioModel user)
        {
            data.deleteUser(user);
        }
    }
}
