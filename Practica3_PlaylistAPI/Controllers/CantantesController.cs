using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practica3_PlaylistAPI.Models;
using Practica3_PlaylistAPI.Services;

namespace Practica3_PlaylistAPI.Controllers
{
    [ApiController]
    [Route("api/cantantes")]
    public class CantantesController : ControllerBase
    {

        private readonly ICantanteInfoRepository _cantanteInfoRepository;
        private readonly IMapper _mapper;
        const int maxCantantesPageSize = 20;

        public CantantesController(ICantanteInfoRepository cantanteInfoRepository,
            IMapper mapper)
        {
            _cantanteInfoRepository = cantanteInfoRepository ?? throw new ArgumentNullException(nameof(cantanteInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CantanteWithoutCancionesDto>>> GetCantantes(
            string? name, string? searchQuery, int pageNumber=1, int pageSize=10)
        {
            if(pageSize > maxCantantesPageSize)
            {
                pageSize = maxCantantesPageSize;
            }
            var cantanteEntities = await _cantanteInfoRepository.GetCantantesAsync(name, searchQuery, pageNumber, pageSize);
            return Ok(_mapper.Map<IEnumerable<CantanteWithoutCancionesDto>>(cantanteEntities));

            //var cantanteEntities = await _cantanteInfoRepository.GetCantantesAsync();
            //var results = new List<CantanteWithoutCancionesDto>();  
            //foreach (var cantanteEntity in cantanteEntities)
            //{
            //    results.Add(new CantanteWithoutCancionesDto
            //    {
            //        Id = cantanteEntity.Id,
            //        Name = cantanteEntity.Name,
            //    });
            //}
            //return Ok(results);
            
            
            //return Ok(_cantantesDataStore.Cantantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCantante(int id, bool includeCanciones = false)
        {

            var cantante = await _cantanteInfoRepository.GetCantanteAsync(id, includeCanciones);
            if(cantante == null)
            {
                return NotFound();
            }

            if (includeCanciones)
            {
                return Ok(_mapper.Map<CantanteDto>(cantante));
            }

            return Ok(_mapper.Map<CantanteWithoutCancionesDto>(cantante));
            
            
            
            //var cantanteToReturn = _cantantesDataStore.Cantantes.FirstOrDefault(c => c.Id == id);

            //if(cantanteToReturn == null)
            //{
            //    return NotFound();
            //}

            //return Ok(cantanteToReturn);
        }

    }
}
