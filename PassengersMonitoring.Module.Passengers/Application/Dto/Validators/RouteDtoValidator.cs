using FluentValidation;

namespace PassengersMonitoring.Module.Passengers.Application.Dto.Validators
{
    public class RouteDtoValidator : AbstractValidator<RouteDto>
    {
        public RouteDtoValidator()
        {
            RuleFor(x => x.OrderNumber).NotEmpty().WithMessage("Route point order number is invalid.");

            RuleFor(x => x.Location).NotEmpty().WithMessage("Route point location is invalid.");

            RuleFor(x => x.RouteNumber).NotEmpty().WithMessage("Route point number is invalid.");
        }
    }
}
