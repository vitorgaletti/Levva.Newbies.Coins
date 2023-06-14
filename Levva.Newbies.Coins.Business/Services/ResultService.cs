using FluentValidation.Results;

namespace Levva.Newbies.Coins.Business.Services
{
    public class ResultService
    {
        public bool hasError { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                hasError = true,
                Message = message,
                Errors = validationResult.Errors
                .Select(x => new ErrorValidation
                {
                    Field = x.PropertyName,
                    Message = x.ErrorMessage
                }).ToList(),
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                hasError = true,
                Message = message,
                Errors = validationResult.Errors
                .Select(x => new ErrorValidation
                {
                    Field = x.PropertyName,
                    Message = x.ErrorMessage
                }).ToList(),
            };
        }

        public static ResultService Fail(string message)
            => new ResultService
            {
                hasError = true,
                Message = message
            };

        public static ResultService<T> Fail<T>(string message)
            => new ResultService<T>
            {
                hasError = true,
                Message = message
            };

        public static ResultService Ok(string message)
            => new ResultService
            {
                hasError = false,
                Message = message
            };

        public static ResultService<T> Ok<T>(T data)
           => new ResultService<T>
           {
               hasError = false,
               Data = data
           };
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
