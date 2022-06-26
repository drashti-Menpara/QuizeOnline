using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuizeAPi.Model
{

   
    public class GetCategoryCommand : IRequest<GetCategoryList>
    {
        public int userid { get; set; }
    }
    public class GetCategoryList
    {
        public List<CategoryList> Category { get; set; }
    }
    public class CategoryList
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
 
}
