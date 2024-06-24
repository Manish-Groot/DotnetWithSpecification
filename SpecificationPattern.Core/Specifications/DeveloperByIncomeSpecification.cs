using System;
using System.Linq.Expressions;
using SpecificationPattern.Core.Entities;

namespace SpecificationPattern.Core.Specifications
{
    public class DeveloperByIncomeSpecification : BaseSpecification<Developer>
    {
        public DeveloperByIncomeSpecification(decimal minIncome)
            : base(developer => developer.Income >= minIncome)
        {
            
        }
    }
}
