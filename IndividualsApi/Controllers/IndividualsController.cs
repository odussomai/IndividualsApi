using System;
using System.Threading.Tasks;
using AutoMapper;
using IndividualsApi.Data;
using IndividualsApi.Data.Entities;
using IndividualsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace IndividualsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualsController : ControllerBase
    {
        private readonly IIndividualsRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public IndividualsController(IIndividualsRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<Individual[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllIndividualsAsync();

                _mapper.Map<IndividualModel[]>(results);

                return Ok(results);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IndividualModel>> Post(IndividualModel model)
        {
            var individual = _mapper.Map<Individual>(model);
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
    }
}