using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto_API.Models;
using Paschoalotto_API.Data;


namespace Paschoalotto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountData data = new AccountData();
        // GET api/account
        [HttpGet]
        public ActionResult<bool> Get()
        {
            return data.hasAccount();            
        }

        // GET api/values/5
        [HttpGet("{user}")]
        public ActionResult<bool> Get(Usuario user)
        {
            return data.hasAccountUser(user);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Usuario user)
        {
            data.insertUser(user);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] Usuario user)
        {
            data.updateUser(user);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete([FromBody] Usuario user)
        {
            data.deleteUser(user);
        }
    }
}
