using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Requests.Developer
{
    public class DeveloperRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Income { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

    }
}
