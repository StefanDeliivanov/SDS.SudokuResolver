using FluentValidation.Results;
using SDS.SudokuResolver.Core.Abstractions.Base;

namespace SDS.SudokuResolver.Core.Abstractions
{
    public interface IEngineResponse : IOperationContract
    {
        int[,] InitialBoard { get; }
        int[,] SolvedBoard { get; } 
        bool Successful { get; }
        ValidationResult ValidationResult { get; }
    }
}