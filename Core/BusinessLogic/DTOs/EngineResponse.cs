using FluentValidation.Results;
using SDS.SudokuResolver.Core.Abstractions;
using SDS.SudokuResolver.Core.BusinessLogic.DTOs.Base;
using static SDS.SudokuResolver.Core.Setup.Settings;

namespace SDS.SudokuResolver.Core.BusinessLogic.DTOs
{
    internal class EngineResponse : BaseDto, IEngineResponse
    {
        public EngineResponse() 
        {
            InitialBoard = new int[gridSize, gridSize];
            SolvedBoard = new int[gridSize, gridSize];
            ValidationResult = new();
        }

        public EngineResponse(int[,] board) : this()
        {
            InitialBoard = board;
            SolvedBoard = board;
        }

        public int[,] InitialBoard { get; init; }

        public int[,] SolvedBoard { get; set; }

        public bool Successful { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}