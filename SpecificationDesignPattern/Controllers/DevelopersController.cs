using Core.Models.ApiResponse;
using Core.Models.Requests.Developer;
using Core.Models.Responses.Developer;
using Core.Specifications;
using Data.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SpecificationPattern.Core.Entities;
using SpecificationPattern.Data;

namespace SpecificationDesignPattern.Controllers
{

    public class DevelopersController : BaseApiController
    {
        private readonly IGenericRepository<Developer> _repositoryDeveloper;
        private readonly ApplicationDbContext _context; 

        public DevelopersController(IGenericRepository<Developer> repository, ApplicationDbContext context)
        {
            _repositoryDeveloper = repository;
            _context = context;
        }


        //[HttpGet]
        //[Route("all")]
        //public async Task<IActionResult> DevResponse()
        //{
        //    var spec = new DeveloperWithAddressSpecification();
        //    var developers = await _repositoryDeveloper.GetAllAsync(spec);
        //    return Ok(developers);
        //}


        [HttpGet]
        [Route("all")]
       // public async Task<IActionResul<ApiResponset>>GetAllDevelopers()
             public async Task<ActionResult<ApiResponse<List<DeveloperResponseModel>>>> GetAllDevelopers(int currentPage, int pageSize)
        {
            try
            {
                var spec = new DeveloperWithAddressSpecification(currentPage, pageSize);
                var developers = await _repositoryDeveloper.GetAllAsync(spec);

                var developerDtos = developers.Select(dev => new DeveloperResponseModel()
                {
                    Id = dev.Id,
                    Name = dev.Name,
                    Income = dev.Income,
                    City = dev.Address.City,
                    Street = dev.Address.Street
                }).ToList();

                var response = new ApiResponse<List<DeveloperResponseModel>>(
                     "Data retrieved successfully", 200, developerDtos);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500,new ApiResponse<List<DeveloperResponseModel>>(
                     "Error retrieving data", 500, null));
            }
        }



        //[HttpPost("create")]
        //public async Task<IActionResult> DevRequest([FromBody] Developer developer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        _context.Developers.Add(developer);
        //        await _context.SaveChangesAsync();

        //        // Return 201 Created status with the newly created developer object
        //        return CreatedAtAction("GetDeveloperById", new { id = developer.Id }, developer);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or return detailed error message
        //        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        //    }
        //}


        [HttpPost("create")]
        public async Task<IActionResult> DevRequest([FromBody] DeveloperRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Map DeveloperRequestModel to Developer entity
                var developer = new Developer
                {
                    Name = model.Name,
                    Income = model.Income,
                    Address = new Address
                    {
                        City = model.City,
                        Street = model.Street
                    }
                };

                var result = _repositoryDeveloper.CreateAsync(developer);
                return Ok(new { Message="New record is created", RecordId = result.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }





        //[HttpGet]
        //[Route("{id}")]
        //public async Task<IActionResult> GetDeveloperById(int id)
        //{
        //    var spec = new DeveloperByIdSpecification(id);

        //    var developer = await _repositoryDeveloper.GetByIdAsync(spec);
        //    if (developer == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(developer);
        //}


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var spec = new DeveloperByIdSpecification(id);
                var developer = await _repositoryDeveloper.GetByIdAsync(spec);

                if (developer == null)
                {
                    return NotFound(new ApiResponse("Developer not found", 404));
                }

                var developerResult = new DeveloperResponseModel { City = developer.Address.City, Income = developer.Income, Name = developer.Name, Street = developer.Address.Street };

                var response = new ApiResponse<DeveloperResponseModel>(
                     "Developer retrieved successfully", 200, developerResult);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new ApiResponse<DeveloperResponseModel>(
                     "Error retrieving developer", 500, null));
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            var spec = new DeveloperByIdSpecification(id);
            var developer = await _repositoryDeveloper.GetByIdAsync(spec);
            if (developer == null)
            {
                return NotFound();
            }

            var result = _repositoryDeveloper.RemoveAsync(developer);

            return Ok(new { Message = "Delete record successfully", RecordId = result.Id }); 
        }
    }
}

//[HttpGet("highincome")]
//public async Task<IActionResult> GetDevelopersWithHighIncome()
//{
//    // Create a specification for developers with income > 100000
//    var spec = new BaseSpecification<Developer>(d => d.Income > 100000);
//    var developers = await _repository.ListAsync(spec);
//    return Ok(developers);
//}
