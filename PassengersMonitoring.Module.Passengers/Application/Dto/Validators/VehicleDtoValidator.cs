using FluentValidation;

namespace PassengersMonitoring.Module.Passengers.Application.Dto.Validators
{
    public class VehicleDtoValidator : AbstractValidator<VehicleDto>
    {
        public VehicleDtoValidator()
        {
            RuleFor(x => x.SitsNumber).NotEmpty().WithMessage("Vehicle sits number is invalid.");

            RuleFor(x => x.VehicleModel).NotEmpty().WithMessage("Vehicle model is invalid.");

            RuleFor(x => x.RouteNumber).NotEmpty().WithMessage("Vehicle route number is invalid.");
        }
    }
}
