using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Games_Storage.Core.Services.Validators
{
    public class NotEmptyListAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field should has at least one element in it";
        public NotEmptyListAttribute()
            :base(DefaultErrorMessage)
        {
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return new ValidationResult(ErrorMessage);

            var list = value as IEnumerable<object>;

            if (list is null)
                return new ValidationResult(ErrorMessage);

            return list.Any() ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
