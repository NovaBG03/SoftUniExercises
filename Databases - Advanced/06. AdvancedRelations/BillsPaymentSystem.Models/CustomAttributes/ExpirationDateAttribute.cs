namespace BillsPaymentSystem.Models.CustomAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ExpirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsDateTime = (DateTime)value;
            var currentDateTime = DateTime.Now;

            if (currentDateTime > valueAsDateTime)
            {
                string errorMsg = "The date has passed!";

                return new ValidationResult(errorMsg);
            }

            return ValidationResult.Success;
        }
    }
}
