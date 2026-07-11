using System.Windows.Controls;

namespace Reflection.BusinessEntity
{
    public class IntegerValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int result = 0;
            if (value == null || value.ToString() == "" || string.IsNullOrWhiteSpace(value.ToString()) == true)
                return new ValidationResult(false, "value cannot be empty.");
            else if (int.TryParse(value.ToString(), out result) == false)
                return new ValidationResult(false, "value cannot be charactors.");
            //else
            //{
            //    if (Convert.ToInt32(value) < 1 || Convert.ToInt32(value) > 100)
            //        return new ValidationResult
            //        (false, "Age cannot be more than 100 & less than 1");
            //}
            return ValidationResult.ValidResult;
        }
    }
    public class StringValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "" || string.IsNullOrWhiteSpace(value.ToString()) == true)
                return new ValidationResult(false, "value cannot be empty.");
            else if (value.ToString().Length > 5)
                return new ValidationResult(false, "value lenght cannot be exceed 5.");
            //else
            //{
            //    if (Convert.ToInt32(value) < 1 || Convert.ToInt32(value) > 100)
            //        return new ValidationResult
            //        (false, "Age cannot be more than 100 & less than 1");
            //}
            return ValidationResult.ValidResult;
        }
    }


    public class NullValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "" || string.IsNullOrWhiteSpace(value.ToString()) == true)
                return new ValidationResult(false, "value cannot be empty.");
            return ValidationResult.ValidResult;
        }
    }
    //public class DecimalValidator : ValidationRule
    //{
    //    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    //    {
    //        decimal result = 0;
    //        if (value == null || value.ToString() == "" || string.IsNullOrWhiteSpace(value.ToString()) == true)
    //            return new ValidationResult(false, "value cannot be empty.");
    //        else if (decimal.TryParse(value.ToString() ,out result) == false)
    //            return new ValidationResult(false, "Insert Only Decimal No.");
    //        //else
    //        //{
    //        //    if (Convert.ToInt32(value) < 1 || Convert.ToInt32(value) > 100)
    //        //        return new ValidationResult
    //        //        (false, "Age cannot be more than 100 & less than 1");
    //        //}
    //        return ValidationResult.ValidResult;
    //    }
    //}
}
