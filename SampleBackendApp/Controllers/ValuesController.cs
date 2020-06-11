using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleBackendApp.Controllers
{
    public class ValuesController : ApiController
    {
        //sample api
        // GET api/values
        private List<string> lstNama; 
        public IEnumerable<string> Get()
        {
            lstNama = new List<string>
            {
                "erick", "bambang","joko","amir"
            };
            return lstNama;
        }

        // GET api/values/5
        public string Get(string nama)
        {
            string result = lstNama.Where(n => n == nama).SingleOrDefault();
            if (result != null)
                return $"Ditemukan: {result}";
            else
                return "Data tidak ditemukan";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
