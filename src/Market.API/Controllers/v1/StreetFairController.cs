using System.Threading.Tasks;
using Market.API.Services.Interfaces;
using Market.API.ViewModels.Request.Pagination;
using Market.API.ViewModels.Request.StreetFair;
using Market.API.ViewModels.Response.Pagination;
using Market.API.ViewModels.Response.StreetFair;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers.v1
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/street-fair")]
    public class StreetFairController : ControllerBase
    {
        private readonly IStreetFairService _streetFairService;

        public StreetFairController(IStreetFairService streetFairService)
        {
            _streetFairService = streetFairService;
        }

        /// <summary>
        ///     Get all street fairs by pagination
        /// </summary>
        /// <remarks>
        ///     Sample request example:
        ///     GET /street-fair (default: Page = 1 and Limit = 30)
        ///     GET /street-fair?page=5&amp;limit=100&amp;name=lageado (other page, limit and filter)
        /// </remarks>
        /// <param name="request"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Street fairs list</response>
        /// <response code="400">Bad request errors</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PaginationResponseViewModel<StreetFairResponseViewModel>>>
            GetAllStreetFairsByPaginationAsync(
                [FromQuery] PaginationRequestViewModel request,
                [FromQuery] StreetFairFilterRequestViewModel filter
            )
        {
            return Ok(await _streetFairService.GetAllStreetFairsByPaginationAsync(request, filter));
        }
    }
}