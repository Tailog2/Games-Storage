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

            IList list = (IList)value;

            if (list is null)
                return new ValidationResult(ErrorMessage);

            return list.Count !=0 ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
