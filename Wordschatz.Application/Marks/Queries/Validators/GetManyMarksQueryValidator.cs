using FluentValidation;

namespace Wordschatz.Application.Marks.Queries.Validators
{
    internal class GetManyMarksQueryValidator : AbstractValidator<GetManyMarksQuery>
    {
        public GetManyMarksQueryValidator()
        {
            RuleFor(x => x.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of dictionary must be positive and not zero.");

            RuleFor(x => x.Amount)
                .InclusiveBetween(1, 500).WithMessage("The amount of marks being fetched must be between 1 and 500.");

            RuleFor(x => x.PageNum)
                .GreaterThanOrEqualTo(1).WithMessage("The page number must be positive and not zero.");
        }
    }
}