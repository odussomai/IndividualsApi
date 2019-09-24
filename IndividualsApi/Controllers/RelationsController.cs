using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualsApi.Data;
using IndividualsApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IndividualsApi.Controllers
{
    [ApiController]
    [Route("api/individuals/{id:int}/Relations")]
    public class RelationsController : Controller
    {
        private readonly IIndividualsRepository _repository;

        public RelationsController(IIndividualsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetRlationsCountByType(int id, int type)
        {
            if (await _repository.GetIndividualAsync(id) == null) return NotFound("Individual Could not be found");

            var relationCount = await _repository.GetRelationCountAsync(id, (RelationType)type);

            return Ok(relationCount);
        }

        [HttpPost]
        public async Task<IActionResult> AddRelative(int id, int type, int relativeId)
        {
            if (await _repository.GetIndividualAsync(id) == null) return NotFound("Individual Could not be found");
            if (await _repository.GetIndividualAsync(relativeId) == null) return NotFound("Relative Could not be found");

            var relation = new Relation
            {
                Type = (RelationType)type,
                IndividualId = id,
                RelativeId = relativeId,
            };

            _repository.Add(relation);

            if (await _repository.SaveChangesAsync())
            {
                return Ok(relation);
            }

            return BadRequest();
        }
    }
}