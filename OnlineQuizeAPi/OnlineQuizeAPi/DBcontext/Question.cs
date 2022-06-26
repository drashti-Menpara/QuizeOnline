using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineQuizeAPi.DBcontext
{
    public partial class Question
    {
        public int Questionid { get; set; }
        public string Questionname { get; set; }
        public int Categoryid { get; set; }
        public bool Isactive { get; set; }
    }
}
