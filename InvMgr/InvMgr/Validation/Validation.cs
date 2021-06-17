using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace InvMgr
{
    public class StringToIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int num;
            if (int.TryParse(value.ToString(), out num))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Enter integer value");
        }
    }

    public class EmptyStringValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Value cannot be empty");
        }
    }
}
