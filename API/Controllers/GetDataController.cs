using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Dal;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ApiController
    {
        Dalcls objDalcls = new Dalcls();


        // GET api/<GetDataController>/5
        public IEnumerable<HomeModel> Get(string id)
        {
            return objDalcls.GetClientDataAPI(id);
        }

    }
}
