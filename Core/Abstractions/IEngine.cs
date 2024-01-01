using SDS.SudokuResolver.Core.Abstractions.Base;

namespace SDS.SudokuResolver.Core.Abstractions
{
    public interface IEngine : IOperationContract
    {
        IEngineResponse SolveBoard(int[,] board);
    }
}