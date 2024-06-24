using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.Core.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Income { get; set; }
        public Address Address { get; set; }

        public static implicit operator List<object>(Developer v)
        {
            throw new NotImplementedException();
        }
    }
}
