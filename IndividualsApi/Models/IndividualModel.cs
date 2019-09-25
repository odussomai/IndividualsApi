using IndividualsApi.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IndividualsApi.Data.Enums;

namespace IndividualsApi.Models
{
    public class IndividualModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be minimum length of 2 and max 50")]
        [RegularExpression("(^[a-zA-Z]+$|^[ა-ჰ]+$)", ErrorMessage = "{0} must be only in Georgian, or Latin alphabet")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be minimum length of 2 and max 50")]
        [RegularExpression("(^[a-zA-Z]+$|^[ა-ჰ]+$)", ErrorMessage = "{0} must be only in Georgian, or Latin alphabet")]
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
        public string Image { get; set; } 

        public List<PhoneModel> Phones { get; set; }

        public List<RelationModel> Relations { get; set; }
    }
}
