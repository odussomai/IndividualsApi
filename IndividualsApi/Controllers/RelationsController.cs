using System.Threading.Tasks;
using IndividualsApi.Data.Entities;
using IndividualsApi.Data.Enums;
using IndividualsApi.Data.Interfaces;
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

        [HttpGet("report")]
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

            //if we want our database to reflect also the reverse relationship, we should construct another relation object
            //depending on business requirements
            _repository.Add(relation);

            if (await _repository.SaveChangesAsync())
            {
                return Ok(relation);
            }

            return BadRequest();
        }


        [HttpDelete("relativeId:int")]
        public async Task<IActionResult> DeleteRelative(int id, int relativeId, int relationType)
        {
            var relation = await _repository.GetRelationByRelativeId(id, relativeId, relationType);

            if (relation == null) return NotFound("Such a relation does not exist");

            _repository.Delete(relation);

            if (await _repository.SaveChangesAsync()) return Ok();

            return BadRequest();
        }
    }
}