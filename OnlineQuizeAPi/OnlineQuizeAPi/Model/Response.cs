using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuizeAPi.Model
{
    public partial class Response
    {
        public Response()
        {

        }
        public string ResponseMessage { get; set; }
        public bool Result { get; set; }
    }
}
