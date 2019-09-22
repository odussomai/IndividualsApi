using IndividualsApi.CustomValidators;
using IndividualsApi.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace IndividualsApi.Models
{
    public class IndividualModel
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 50 characters")]
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 50 characters")]
        [Required(ErrorMessage = "Surname is required")]
        public string LastName { get; set; }

        [Range(0, 1)]
        public BinarySex Sex { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage ="Please enter proper personal Id")]
        [Required]
        public string PersonalId { get; set; }

        [MinimumAge(18)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
