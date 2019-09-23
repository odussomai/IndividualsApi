using IndividualsApi.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace IndividualsApi.Models
{
    public class PhoneModel
    {
        public PhoneType Type { get; set; }

        [StringLength(50, MinimumLength = 4)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone should be between 4 and 50 characters")]
        public string PhoneNumber{ get; set; }
    }
}