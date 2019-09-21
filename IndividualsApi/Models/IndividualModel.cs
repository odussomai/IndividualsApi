using IndividualsApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualsApi.Models
{
    public class IndividualModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public BinarySex Sex { get; set; }
        [Required]
        public string PersonalId { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }


        public string City { get; set; }
    }
}
