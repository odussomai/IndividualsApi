using System.Threading.Tasks;
using AutoMapper;
using IndividualsApi.Data;
using IndividualsApi.Data.Entities;
using IndividualsApi.Filters;
using IndividualsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;

namespace IndividualsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ModelValidationFilter]
    public class IndividualsController : ControllerBase
    {
        private readonly IIndividualsRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IStringLocalizer<IndividualsController> _localizer;

        public IndividualsController(IIndividualsRepository repository,
                                     IMapper mapper,
                                     LinkGenerator linkGenerator,
                                     IStringLocalizer<IndividualsController> localizer)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._linkGenerator = linkGenerator;
            this._localizer = localizer;
        }

        [HttpGet]
        public async Task<ActionResult<IndividualModel[]>> Get(int pageIndex = 1, int pageSize = 25)
        {
            var results = await _repository.GetAllIndividualsAsync(pageIndex, pageSize);

            return Ok(_mapper.Map<IndividualModel[]>(results));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IndividualModel>> Get(int id)
        {
            var result = await _repository.GetIndividualAsync(id);

            if (result == null) return NotFound(_localizer["Individual could not be found"]);
 
            return Ok(_mapper.Map<IndividualModel>(result));
        }

        [HttpGet("search")]
        public async Task<ActionResult<IndividualModel[]>> Search(string term)
        {
            var results = await _repository.Search(term);

            return Ok(_mapper.Map<IndividualModel[]>(results));
        }

        [HttpPost]
        public async Task<ActionResult<IndividualModel>> Post(IndividualModel model)
        {
            var individual = _mapper.Map<Individual>(model);

            if(model.CityId != 0)
            {
                var city = await _repository.GetCityByIdAsync(model.CityId);

                if (city == null) return BadRequest(_localizer["City with the given Id could not be found"]);

                individual.City = city;
                individual.CityId = city.Id;
            }

            _repository.Add(individual);

            if (await _repository.SaveChangesAsync())
            {
                var url = _linkGenerator.GetPathByAction("Get", "Individuals", new
                {
                    id = individual.Id
                });

                return Created(url, _mapper.Map<IndividualModel>(individual));
            }

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IndividualModel>> Put(int id, IndividualModel model)
        {
            var existing = await _repository.GetIndividualAsync(id);
                
            if(existing == null) return NotFound(_localizer["Individual Could not be found"]);

            _mapper.Map(model, existing);
            
            if (model.CityId != 0)
            {
                var city = await _repository.GetCityByIdAsync(model.CityId);

                if (city == null) return BadRequest(_localizer["City with the given Id could not be found"]);

                existing.CityId = city.Id;
                existing.City = city;
            }

            if (await _repository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<IndividualModel>(existing));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repository.GetIndividualAsync(id);

            if (existing == null) return NotFound(_localizer["Individual Could not be found"]);

            _repository.Delete(existing);

            if(await _repository.SaveChangesAsync())
            {
                return Ok();
            }

            return BadRequest();
        }
        
    }


}