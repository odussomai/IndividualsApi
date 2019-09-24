using System.ComponentModel.DataAnnotations.Schema;

namespace IndividualsApi.Data.Entities
{
    public class Relation
    {
        public int Id { get; set; }
        public RelationType Type { get; set; }

        public int IndividualId { get; set; }

        [ForeignKey(nameof(IndividualId))]
        public Individual individual{ get; set; }

        public int RelativeId { get; set; }

        [ForeignKey(nameof(RelativeId))]
        public Individual Relative { get; set; }
    }
}
