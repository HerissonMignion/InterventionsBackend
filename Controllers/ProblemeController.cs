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
    public async Task<ActionResult<IEnumerable<TypeProbleme>>> GetTypeProblemeAsync()
    {
        try {
            var infos = await _ProblemeRepository.GetTypeProblemeAsync();
            var infosDTO = _mapper.Map<IEnumerable<TypeProblemeDTO>>(infos);
            return Ok(infosDTO);

        }
        catch (Exception ex) {
            _logger.LogError($"Erreur dans l'obtention des données du repo : {ex}");
            return Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{Id:int}", Name = "GetProbleme")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Probleme>> GetProblemeAsync(int? Id)
    {
        // Vérifier si Id est présent
        if (Id == null)
        {
            return BadRequest();
        }

        try
        {
            var infos = await _ProblemeRepository.GetProblemeAsync(Id);
            if (infos == null) {
                return NotFound();
            }
            var infosDTO = _mapper.Map<ProblemeDTO>(infos);
            return Ok(infosDTO);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erreur dans l'obtention des données du repo : {ex}");
            return Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<TypeProbleme>>> GetTypesProblemeAsync()
    {
        try
        {
            var infos = await _ProblemeRepository.GetTypeProblemeAsync();
            var infosDTO = _mapper.Map<IEnumerable<TypeProblemeDTO>>(infos);
            return Ok(infosDTO);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erreur dans l'obtention des données dans la base de données : {ex}");
            return Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProblemeDTO>> CreateProbleme([FromBody] ProblemeDTO problemeDTO)
    {
        try
        {
            var probleme = _mapper.Map<Probleme>(problemeDTO);

            probleme.dateProbleme = System.DateTime.Now;

            int? Id = await _ProblemeRepository.CreateProblemeAsync(probleme);

            if (Id != null) {
                var convertedProblemeDTO = _mapper.Map<ProblemeDTO>(probleme);
                // var convertedProblemeDTO = _mapper.Map<ProblemeDTO>(await this._ProblemeRepository.GetProblemeAsync(Id));
                return CreatedAtRoute("GetProbleme", new { Id = probleme.Id }, convertedProblemeDTO);
            }

            return Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erreur dans l'enregistrement des données du repo : {ex}");
            return Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
    }







}