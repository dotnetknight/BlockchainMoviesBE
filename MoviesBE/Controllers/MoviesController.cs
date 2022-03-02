using AutoMapper;
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
        private readonly IMapper _mapper;

        public MoviesController(ILogger<MoviesController> logger, MoviesService moviesService, IMapper mapper)
        {
            _logger = logger;
            _moviesService = moviesService;
            _mapper = mapper;
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

            var movieToAdd = _mapper.Map<MoviesStructure>(request);
            await _moviesService.AddMovieRequestAndWaitForReceiptAsync(movieToAdd, request.SenderAddress);
            return CreatedAtAction(null, null);
        }
    }
}