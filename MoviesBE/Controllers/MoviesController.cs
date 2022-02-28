using Microsoft.AspNetCore.Mvc;
using Movies.Models.Contracts;
using Movies.Models.Requests;
using Movies.Services;

namespace MoviesBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly MoviesService _moviesService;

        public MoviesController(ILogger<MoviesController> logger, MoviesService moviesService)
        {
            _logger = logger;
            _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<IEnumerable<MoviesStructure>> Get()
        {
            _logger.Log(LogLevel.Information, "Getting movies from blockchain");

            var result = await _moviesService.GetMoviesQueryAsync();
            return result.Movies.OrderBy(x => x.Id).ThenBy(x => x.Name);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddMovieRequest request)
        {
            _logger.Log(LogLevel.Information, "Adding new movie");

            await _moviesService.AddMovieRequestAndWaitForReceiptAsync(request.Id, request.Name, request.Director, request.SenderAddress);
            return CreatedAtAction(null, null);
        }
    }
}