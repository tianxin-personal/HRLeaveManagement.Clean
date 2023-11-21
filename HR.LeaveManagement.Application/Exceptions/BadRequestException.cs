
using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        private readonly List<string> _errors = new List<string>();
        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            _errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
