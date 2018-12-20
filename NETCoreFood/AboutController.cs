using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreFood
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("phone")]
        public string phoneNumber()
        {
            return "Phone Number ";
        }
        [Route("[action]")]
        public string Address()
        {

            return "INDIA";
        }

    }
}
