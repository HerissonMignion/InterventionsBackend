using AutoMapper;
using InterventionsBackend.Entities;
using InterventionsBackend.Models;
using InterventionsBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InterventionsBackend.Controllers;

// http[s]://localhost[:.*]/probleme
[ApiController]
[Route("v{version:apiversion}/probleme")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[EnableRateLimiting("LimiterFenetre")]

public class ProblemeController : ControllerBase {

    private readonly IProblemeRepository _ProblemeRepository;

    private readonly ILogger<ProblemeController> _logger;

    private readonly IMapper _mapper;

    public ProblemeController(IProblemeRepository problemeRepository,
        ILogger<ProblemeController> logger,
        IMapper mapper)
    {
        this._ProblemeRepository = problemeRepository ??
            throw new ArgumentNullException(nameof(problemeRepository));
        this._logger = logger ??
            throw new ArgumentNullException(nameof(logger));
        this._mapper = mapper ??
            throw new ArgumentNullException(nameof(logger));
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<TypeProbleme>>> GetProblemeAsync()
    {
        try {
            var infos = await _ProblemeRepository.GetProblemeAsync();
            var infosDTO = _mapper.Map<IEnumerable<TypeProblemeDTO>>(infos);
            return Ok(infosDTO);

        }
        catch (Exception ex) {
            _logger.LogError($"Erreur dans l'obtention des données du repo : {ex}");
            return Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
    }








    

}