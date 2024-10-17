using backend_hdeleon.Models.DTOs;
using FluentValidation;

namespace backend_hdeleon.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {

            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
