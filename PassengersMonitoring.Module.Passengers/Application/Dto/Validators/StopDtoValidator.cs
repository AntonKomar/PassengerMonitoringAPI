using FluentValidation;

namespace PassengersMonitoring.Module.Passengers.Application.Dto.Validators
{
    public class StopDtoValidator : AbstractValidator<StopDto>
    {
        public StopDtoValidator()
        {
            RuleFor(x => x.PassengersNumber).NotEmpty().WithMessage("Passengers number of the stop is invalid.");

            RuleFor(x => x.Location).NotEmpty().WithMessage("Location of the stop is invalid.");

            RuleFor(x => x.Timestamp).NotEmpty().WithMessage("Stop timestamp is invalid.");
        }
    }
}
