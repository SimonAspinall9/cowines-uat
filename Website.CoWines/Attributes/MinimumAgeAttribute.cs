namespace Website.CoWines.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MinimumAgeAttribute : ValidationAttribute
    {
        private int _minimumAge;
        private string _errorMessage;

        public MinimumAgeAttribute(int minimumAge, string errorMessage = null)
        {
            _minimumAge = minimumAge;
            _errorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            var isOver18 = false;
            var dateOfBirth = DateTime.Today;
            if (DateTime.TryParse(value.ToString(), out dateOfBirth))
            {
                isOver18 = dateOfBirth.AddYears(_minimumAge) <= DateTime.Today;
            }

            if (!isOver18 && string.IsNullOrEmpty(ErrorMessage)) ErrorMessage = "Access Denied. Date of birth entered is not valid.";

            return isOver18;
        }
    }
}
