using System;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ValidValue : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
            {
                string strValue = value.ToString(); // All commented code in this function is because of file shifting to Business Entity project. correct later if using.

                if (value == null || value.ToString().Trim() == "" || string.IsNullOrWhiteSpace(value.ToString()) == true) // || AppSessionState.StringListValue == null
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                //else if (AppSessionState.StringListValue != null && AppSessionState.StringListValue.FindIndex(x => x.Equals(value.ToString(), StringComparison.OrdinalIgnoreCase)) == -1)
                //    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                else
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
        }
    }

    class ReflectionValidationAttributes
    {
    }

    //public class Unqiue : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        var contains = CustomerViewModel.SharedViewModel().Customers.Select(x => x.Id).Contains(int.Parse(value.ToString()));

    //        if (contains)
    //            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    //        else
    //            return ValidationResult.Success;
    //    }
    //}
}
