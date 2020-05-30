using FluentValidation;

namespace Wordschatz.Application.Dictionaries.Queries.Validators
{
    class DictionaryGetByIdQueryValidator : AbstractValidator<DictionaryGetByIdQuery>
    {
        public DictionaryGetByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("The identifier of the dictionary cannot be a null value")
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the dictionary must be a positive non-zero number");
        }
    }
}
