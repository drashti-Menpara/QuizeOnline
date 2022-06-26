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
    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand, Response> {
        private readonly QuizeDBContext _dbContext;
        public AddQuestionCommandHandler(QuizeDBContext dbContext)
           : base()
        {
            _dbContext = dbContext;
        }
        public Task<Response> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            Response response = new Response();
            int questionid = AddQuestion(request);
            AddOptionsdata(request, questionid);
            AddAnswerData(request, questionid);
            response.ResponseMessage = "Successfully added";
            response.Result = true;
            return Task.FromResult(response);
        }
        public int AddQuestion(AddQuestionCommand request) {
            Response response = new Response();
            Question qdata = new Question
            {
                Questionname = request.QuestionName,
                Categoryid = request.Categoryid,
                Isactive = request.isactive

            };
            if (request.Categoryid < 0)
            {
                response.ResponseMessage = "Category is not selected";
            }
            _dbContext.Questions.Add(qdata);
            _dbContext.SaveChanges();
            return qdata.Questionid;
        }
        public void AddOptionsdata(AddQuestionCommand request, int questionid) {
            if (questionid > 0) { 
                foreach(var opt in request.Optiondata)
                {
                    Option op = new Option
                    {
                        Questionid = questionid,
                        Optionname = opt.OptionName,
                    };
                    _dbContext.Options.Add(op);
                }
            }
            _dbContext.SaveChanges();
        }
        public void AddAnswerData(AddQuestionCommand request, int questionid)
        {
            Response response = new Response();
            Answer ansdata = new Answer
            {
                Answertext= request.Answertext,
                Questionid = questionid
            };
            if (request.Categoryid < 0 && questionid < 0)
            {
                response.ResponseMessage = "Category is not selected and Question is not added";
            }
            _dbContext.Answers.Add(ansdata);
            _dbContext.SaveChanges();
        }
    }

}

