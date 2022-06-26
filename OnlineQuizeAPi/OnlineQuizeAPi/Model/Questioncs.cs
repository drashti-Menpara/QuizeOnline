using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuizeAPi.Model
{
    public class GetQuestionsCommand : IRequest<GetquetionResponse>
    {
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
    }
    public class GetquetionResponse
    {
        public List<GetquetionResponses> Data { get; set; } = new List<GetquetionResponses>();
    }
    public class GetquetionResponses
    {
        public int quesionid { get; set; }
        public int categoryid { get; set; }
        public string questionname { get; set; }
        public List<Optionslist> optiondata { get; set; }
    }
    public class Optionslist
    {
        public int optionid { get; set; }
        public int optiontext { get; set; }
    }
    public class AddQuestionCommand : IRequest<Response>
    {
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
        public bool isactive { get; set; }
        public string QuestionName { get; set; }
        public List<OptionData> Optiondata { get; set; }
        public string Answertext { get; set; }
    }
    public class QuestionData
    {
        public int Questionid { get; set; }
        public string QuestionName { get; set; }
        public List<OptionData> Optiondata { get; set; }
    }
    public class OptionData
    {
        public string OptionName { get; set; }
    }
}
