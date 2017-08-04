using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwaggerWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private string[] lista
        {
            get
            {
                if (System.Web.HttpContext.Current.Application[(< em > "lista" </ em >)] == null)
                {
                    System.Web.HttpContext.Current.Application[< em > "lista" </ em >] =
                        new string[] { < em > "value1" </ em >, < em > "value2" </ em > };
                }
                return
                    (string[])System.Web.HttpContext.Current.Application[< em > "lista" </ em >];
            }
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return lista;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return lista[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
