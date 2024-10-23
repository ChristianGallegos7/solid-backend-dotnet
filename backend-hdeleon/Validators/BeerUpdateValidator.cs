using backend_hdeleon.Models.DTOs.Beer;
using FluentValidation;

namespace backend_hdeleon.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator()
        {
            RuleFor(x => x.BeerId).NotNull().WithMessage("El id es obligatorio");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Name).Length(3, 20).WithMessage("El nombre debe tener entre 3 y 20 caracteres");
        }
    }
}
