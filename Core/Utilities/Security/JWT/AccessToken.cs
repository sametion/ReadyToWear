using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public  class AccessToken                    //erişim için bu tkenle birlikte gel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
