using Core.Models.Responses.Developer;

namespace SpecificationDesignPattern.Controllers
{
    internal class Return_Response
    {
        private string v1;
        private int v2;

        public Return_Response(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public List<DeveloperResponseModel> Data { get; set; }
    }
}