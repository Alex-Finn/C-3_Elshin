using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTestMailSender.Services
{
    public class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string str)
            {
                if (str == String.Empty) return new ValidationResult(false, "Имя не должно быть пустым");
                if (str.Length < 3) return new ValidationResult(false,"По правилам - имя длиннее 3 символов");
            }
            return ValidationResult.ValidResult;
        }
    }
}
