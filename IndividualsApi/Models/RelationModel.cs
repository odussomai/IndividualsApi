using IndividualsApi.Data.Entities;
using IndividualsApi.Data.Enums;

namespace IndividualsApi.Models
{
    public class RelationModel
    {
        public RelationType Type { get; set; }

        public IndividualModel Related { get; set; }
    }
}
