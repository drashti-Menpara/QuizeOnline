using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuizeAPi.Model
{
    public class GetQuestionListCommand : IRequest<GetQuestions>
    {
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
    }

    public class GetQuestions
    {
        public List<Questions> questions { get; set; }
    }
    public class Questions {
        public int quesntionId { get; set; }
        public string questionname { get; set; }
        public List<Options> options {get; set;}
        public List<Answers> answers { get; set; }
    }
    public class Options { 
        public int optionid { get; set;  }
        public string optionname { get; set;  }
    }
    public class Answers { 
        public int answerid { get; set; }
        public string asnwertext { get; set; }
    }
}
