namespace Website.CoWines.ViewModel
{
    using Attributes;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ValidateAgeViewModel
    {
        [Required]
        [MinimumAge(18)]
        public DateTime DateOfBirth { get; set; }
    }
}
