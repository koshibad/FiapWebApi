using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OWINKatana
{
    public class HelloController : ApiController
    {
        public Hello Get()
        {
            return new Hello { Texto = "Hello!!!" };
        }
    }
}
