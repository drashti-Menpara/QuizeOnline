using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineQuizeAPi.DBcontext
{
    public partial class Option
    {
        public int Optionid { get; set; }
        public string Optionname { get; set; }
        public int Questionid { get; set; }
    }
}
