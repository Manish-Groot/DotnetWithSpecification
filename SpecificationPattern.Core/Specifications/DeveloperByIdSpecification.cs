using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecificationPattern.Core.Entities;
using SpecificationPattern.Core.Specifications;

namespace Core.Specifications
{
    public class DeveloperByIdSpecification: BaseSpecification<Developer>
    {
        public DeveloperByIdSpecification(int id): base(x => x.Id == id)
        {
            AddInclude(x => x.Address);
        }
    }
}
