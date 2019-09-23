using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndividualsApi.Data.Entities
{
    [Table("Individuals")]
    public class Individual
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        public BinarySex Sex { get; set; }

        [MaxLength(11)]
        [MinLength(11)]
        [Required]
        public string PersonalId { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int? CityId { get; set; }

        [ForeignKey("CityId")]
        public City City{ get; set; }

        public string Image { get; set; }

        public ICollection<Phone> PhoneNumbers { get; set; }


        [InverseProperty("Individual")]
        public ICollection<Relation> Relatives { get; set; }
    }
}
