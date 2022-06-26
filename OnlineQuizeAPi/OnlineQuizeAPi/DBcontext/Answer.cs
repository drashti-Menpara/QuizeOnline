using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineQuizeAPi.DBcontext
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int Questionid { get; set; }
        public string Answertext { get; set; }
    }
}
