using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Practica3_PlaylistAPI.Models;
using Practica3_PlaylistAPI.Services;

namespace Practica3_PlaylistAPI.Controllers
{
    [Route("api/cantantes/{cantanteId}/canciones")]
    [ApiController]
    public class CancionesController : ControllerBase
    {
        private readonly ILogger<CancionesController> _logger;
        private readonly ICantanteInfoRepository _cantanteInfoRepository;
        private readonly IMapper _mapper;

        public CancionesController(ILogger<CancionesController> logger, ICantanteInfoRepository cantanteInfoRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cantanteInfoRepository = cantanteInfoRepository ?? throw new ArgumentNullException(nameof(cantanteInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancionDto>>> GetCanciones(int cantanteId)
        {
            if(!await _cantanteInfoRepository.CantanteExistsAsync(cantanteId))
            {
                _logger.LogInformation($"Cantante con id {cantanteId} no se ha encontrado al acceder a canciones");
                return NotFound();
            }

            var cancionesForCantante = await _cantanteInfoRepository.GetCancionesForCantanteAsync(cantanteId);
            return Ok(_mapper.Map<IEnumerable<CancionDto>>(cancionesForCantante));

            //try
            //{
            //    var cantante = _cantantesDataStore.Cantantes.FirstOrDefault(c => c.Id == cantanteId);

            //    if(cantante == null)
            //    {
            //        _logger.LogInformation($"Cantante con id {cantanteId} no se encuentra al acceder a sus canciones");
            //        return NotFound();
            //    }
            
            //    return Ok(cantante.Canciones);
            //}
            //catch(Exception ex)
            //{
            //    _logger.LogCritical($"Exception while getting of canciones para cantante con id {cantanteId}", ex);
            //    return StatusCode(500, "A problem happened while handling your request.");
            //}
        }

        [HttpGet("{cancionid}" , Name = "GetCancion")]
        public async Task<ActionResult<CancionDto>> GetCancion(int cantanteId, int cancionId)
        {
            if(!await _cantanteInfoRepository.CantanteExistsAsync(cantanteId))
            {
                return NotFound();
            }
            var cancion = await _cantanteInfoRepository.GetCancionForCantanteAsync(cantanteId, cancionId);

            if(cancion == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CancionDto>(cancion));



            //var cantante = _cantantesDataStore.Cantantes.FirstOrDefault(c => c.Id == cantanteId);

            //if (cantante == null)
            //{
            //    return NotFound();
            //}

            //var cancion = cantante.Canciones.FirstOrDefault(c => c.Id == cancionId);
            //if(cancion == null)
            //{
            //    return NotFound();
            //}
            //return Ok(cancion);
        }

        [HttpPost]
        public async Task<ActionResult<CancionDto>> CreateCancion(int cantanteId, CancionForCreationDto cancion)
        {
            if(!await _cantanteInfoRepository.CantanteExistsAsync(cantanteId))
            {
                return NotFound();
            }

            var finalCancion = _mapper.Map<Entities.Cancion>(cancion);

            await _cantanteInfoRepository.AddCancionForCantanteAsync(cantanteId, finalCancion);
            await _cantanteInfoRepository.SaveChangesAsync();

            var createdCancionToReturn = _mapper.Map<Models.CancionDto>(finalCancion);
            return CreatedAtRoute("GetCancion",
                new
                {
                    cantanteId = cantanteId,
                    cancionId = createdCancionToReturn.Id
                },
                createdCancionToReturn);
        }

        [HttpPut("{cancionid}")]
        public async Task<ActionResult> UpdateCancion(int cantanteId, int cancionId, CancionForUpdateDto cancion)
        {
            if (!await _cantanteInfoRepository.CantanteExistsAsync(cantanteId))
            {
                return NotFound();
            }

            var cancionEntity = await _cantanteInfoRepository.GetCancionForCantanteAsync(cantanteId, cancionId);

            if (cancionEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(cancion, cancionEntity);

            await _cantanteInfoRepository.SaveChangesAsync();

            return NoContent();

        }

        [HttpPatch("{cancionid}")]
        public async Task<ActionResult> PartiallyUpdateCancion(int cantanteId, int cancionId,
            JsonPatchDocument<CancionForUpdateDto> patchDocument)
        {
            if (!await _cantanteInfoRepository.CantanteExistsAsync(cantanteId))
            {
                return NotFound();
            }

            var cancionEntity = await _cantanteInfoRepository.GetCancionForCantanteAsync(cantanteId, cancionId);

            if (cancionEntity == null)
            {
                return NotFound();
            }

            var cancionToPatch = _mapper.Map<CancionForUpdateDto>(cancionEntity);


            patchDocument.ApplyTo(cancionToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(cancionToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(cancionToPatch, cancionEntity);
            await _cantanteInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{cancionId}")]
        public async Task<ActionResult> DeleteCancion(int cantanteId, int cancionId)
        {
            if (!await _cantanteInfoRepository.CantanteExistsAsync(cantanteId))
            {
                return NotFound();
            }

            var cancionEntity = await _cantanteInfoRepository.GetCancionForCantanteAsync(cantanteId, cancionId);

            if (cancionEntity == null)
            {
                return NotFound();
            }

            _cantanteInfoRepository.DeleteCancion(cancionEntity);
            await _cantanteInfoRepository.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
