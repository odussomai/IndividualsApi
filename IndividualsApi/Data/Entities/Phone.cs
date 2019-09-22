using System.ComponentModel.DataAnnotations;

namespace IndividualsApi.Data.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public PhoneType Type { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public int IndividualId { get; set; }
    }
}