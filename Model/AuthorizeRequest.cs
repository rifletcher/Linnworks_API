using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linnworks_API.Model
{
    class AuthorizeRequest
    {
        public string ApplicationId { get; set; }
        public string ApplicationSecret { get; set; }
        public string Token { get; set; }

    }
}
