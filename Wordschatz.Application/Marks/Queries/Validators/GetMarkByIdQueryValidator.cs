using FluentValidation;

namespace Wordschatz.Application.Marks.Queries.Validators
{
    internal class GetMarkByIdQueryValidator : AbstractValidator<GetMarkByIdQuery>
    {
        public GetMarkByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("The theme's identifier must be positive and not zero.");

            RuleFor(x => x.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The dictionary's identifier must be positive and not zero.");
        }
    }
}