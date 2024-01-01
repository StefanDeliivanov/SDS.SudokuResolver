using FluentValidation;

namespace SDS.SudokuResolver.Core.Setup.Validators
{
    public class BoardValidator : AbstractValidator<int[,]>
    {
        public BoardValidator()
        {
        }
    }
}