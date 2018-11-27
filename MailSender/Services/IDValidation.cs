using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTestMailSender.Services
{
    public class IDValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string str)
            {
                if (!int.TryParse(str, out var i)) return new ValidationResult(false, "Строка имела недопустимый формат");
                value = i;
            }
            if (!(value is int id)) return new ValidationResult(false, "Некорректный ввод");

            if (id < 0) return new ValidationResult(false, "Модификатор должен быть больше нуля");
            return ValidationResult.ValidResult;
        }
    }
}
