using SpecificationPattern.Core.Entities;
using Core.Specifications;
using SpecificationPattern.Core.Specifications;
using System.Linq.Expressions;

public class DeveloperWithAddressSpecification : BaseSpecification<Developer>
{
   
    public DeveloperWithAddressSpecification(int currentPage, int pageSize) :base()
    {
        AddInclude(x => x.Address);
        ApplyPaging(pageSize * (currentPage - 1), pageSize);
    }
}
