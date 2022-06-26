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
    public class GetCategoryCommandHandler : IRequestHandler<GetCategoryCommand, GetCategoryList>
    {
        private readonly QuizeDBContext _dbContext;
        public GetCategoryCommandHandler(QuizeDBContext dbContext)
           : base()
        {
            _dbContext = dbContext;
        }
       
        public Task<GetCategoryList> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {
            GetCategoryList cdata = new GetCategoryList();
            var gc = (from c in _dbContext.Categories
                      select new CategoryList()
                      {
                          CategoryName = c.Categoryname,
                          CategoryId = c.Categoryid
                      }).ToList();
            cdata.Category = gc;
            return Task.FromResult(cdata);
        }
    }
}
