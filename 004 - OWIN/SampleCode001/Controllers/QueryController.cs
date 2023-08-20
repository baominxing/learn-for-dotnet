using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode001.Controllers
{
    internal class QueryController
    {
        // GET api
        public string Get(string id)
        {
            return id;
        }
        // POST api
        public PostDto Post(PostDto dp)
        {
            return dp;
        }
        // PUT api
        public void Put(int id, string value)
        {
        }
        // DELETE api
        public void Delete(int id)
        {
        }
    }

    public class PostDto
    {
        public int id;

        public string? name;
    }
}
