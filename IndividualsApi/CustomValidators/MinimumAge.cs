using System;
using System.ComponentModel.DataAnnotations;

namespace IndividualsApi.CustomValidators
{
    public class MinimumAge : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAge(int age)
        {
            _minimumAge = age;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var birthDate = ((DateTime)value);

            DateTime now = DateTime.Today;
            int age = now.Year - birthDate.Year;
            if (birthDate > now.AddYears(-age)) age--;

            if (age < _minimumAge)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public int MinAge => _minimumAge;

        public string GetErrorMessage()
        {
            return $"Age should not be less than {_minimumAge}.";
        }
    }
}
