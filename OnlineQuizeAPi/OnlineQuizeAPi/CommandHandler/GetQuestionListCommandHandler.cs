using MediatR;
using OnlineQuizeAPi.DBcontext;
using OnlineQuizeAPi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineQuizeAPi.CommandHandler
{
    public class GetQuestionListCommandHandler : IRequestHandler<GetQuestionListCommand, GetQuestions>
    {
        private readonly QuizeDBContext _dbContext;
        public GetQuestionListCommandHandler(QuizeDBContext dbContext)
           : base()
        {
            _dbContext = dbContext;
        }
        public Task<GetQuestions> Handle(GetQuestionListCommand request, CancellationToken cancellationToken)
        {
            GetQuestions getQuestions = new GetQuestions();
            getQuestions.questions=Getquestiondata(request);
            return Task.FromResult(getQuestions);
        }
        public List<Questions> Getquestiondata(GetQuestionListCommand request)
        {
            List<Questions> questiondata = new List<Questions>();
            questiondata = (from que in _dbContext.Questions
                            where que.Categoryid == request.Categoryid
                            select new Questions()
                            {
                                quesntionId = que.Questionid,
                                questionname = que.Questionname
                            }).ToList();

            foreach (var res in questiondata)
            {
                res.options = Getoptionsdata(res.quesntionId);
            }
            foreach (var res in questiondata)
            {
                res.answers = Getanswerdata(res.quesntionId);
            }
            return questiondata;
        }
        public List<Options> Getoptionsdata(int questionid) {
            List<Options> Optionsdata = new List<Options>();
            Optionsdata = (from op in _dbContext.Options
                          where op.Questionid == questionid
                          select new Options()
                          {
                              optionid = op.Optionid,
                              optionname = op.Optionname
                          }).ToList();
            return Optionsdata;
        }
        public List<Answers> Getanswerdata(int questionid)
        {
            List<Answers> Answersdata = new List<Answers>();
            Answersdata = (from op in _dbContext.Answers
                           where op.Questionid == questionid
                           select new Answers()
                           {
                               answerid = op.Id,
                               asnwertext = op.Answertext
                           }).ToList();
            return Answersdata;
        }

    }
}
