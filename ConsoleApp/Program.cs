using SDS.SudokuResolver.Core.BusinessLogic;
using System.Text.RegularExpressions;
using static SDS.SudokuResolver.Core.Setup.Settings;
using static SDS.SudokuResolver.Core.Setup.Settings.ConsoleAppConstants;

namespace SDS.SudokuResolver.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new ResolveEngine();

            Console.WriteLine(AsciiArt.welcomeTextShimrod);
            Console.WriteLine($"If you want to exit the application at any time just write the command '{stopProgramCommand}'");
            string input = string.Empty;         

            while (IsNotExitCommand(input))
            {
                SelectLoadType();

                if (IsNotExitCommand(input))
                {
                    if (IsManuallyLoadType())
                    {
                        var board = CreateBoard();

                        while (true)
                        {
                            bool printBoard = true;

                            if (printBoard)
                            {
                                Printer.PrintBoard(board);
                                Console.WriteLine();
                            }

                            Console.WriteLine($"Is the board correct? {yesOrNoPossibleAnswers}: ");
                            input = Console.ReadLine();

                            if (IsNotExitCommand(input))
                            {
                                if (IsYesAnswer())
                                {
                                    var result = engine.SolveBoard(board);

                                    if (result.Successful)
                                    {
                                        Console.WriteLine(defaultSuccessMessage);
                                        Printer.PrintBoard(result.SolvedBoard, 50);
                                    }
                                    else Console.WriteLine(defaultFailMessage);

                                    break;
                                }
                                else if (IsNoAnswer())
                                {
                                    board = CreateBoard();
                                    printBoard = true;
                                    continue;
                                }
                                else
                                {
                                    while (true)
                                    {
                                        Console.WriteLine(invalidCommandMessage);
                                        printBoard = false;
                                        continue;
                                    }
                                }
                            }
                        }

                        // ------------
                        LoadAnotherBoardPrompt();
                        continue;
                    }
                    else if (IsFromFileLoadType())
                    {
                        Console.WriteLine("Some stuff done for 'from-file'");
                        LoadAnotherBoardPrompt();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(invalidCommandMessage);
                        continue;
                    }
                }
            }

            bool IsNotExitCommand(string command)
            {
                if (command == stopProgramCommand)
                    ExitProgram();

                return true;
            }
   
            void SelectLoadType()
            {
                Console.WriteLine();
                Console.Write($"Please select how you want to load board? '{ConsoleLoadBoardTypes.Manually}/{ConsoleLoadBoardTypes.From_file}': ");
                input = Console.ReadLine();
            }

            void ExitProgram()
            {
                Console.WriteLine();
                Console.WriteLine("Thanks you for using our 'Sudoku Resolver' and hope you enjoyed it!");
                Console.WriteLine("GoodBye!");
                Environment.Exit(0);
            }

            void LoadAnotherBoardPrompt()
            {
                while (true)
                {
                    Console.Write($"Would you like to load another board? {yesOrNoPossibleAnswers}: ");
                    input = Console.ReadLine();

                    if (IsNotExitCommand(input))
                    {
                        if (IsYesAnswer())
                            break;
                        else if (IsNoAnswer())
                            ExitProgram();
                        else
                        {
                            Console.WriteLine(invalidCommandMessage);
                            continue;
                        }
                    }
                }
            }

            int[,] CreateBoard()
            {
                var board = new int[gridSize, gridSize];
                var rx = new Regex(consoleReadRowRegexPattern);
                string row;

                for (int i = 0; i < gridSize; i++)
                {
                    row = ReadRow(i + 1);

                    while (true)
                    {
                        if (IsNotExitCommand(row) && rx.IsMatch(row))
                            break;

                        Console.WriteLine(invalidCommandMessage);
                        row = ReadRow(i + 1);
                    }

                    int[] validRow = row.Split(consoleReadRowDelimiter, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                    for (int j = 0; j < gridSize; j++)
                    {
                        board[i, j] = validRow[j];
                    }
                }
                return board;
            }

            string ReadRow(int i)
            {
                Console.WriteLine($"Please enter values for row #{i} following the pattern '{consoleReadRowUIPattern}' where '#' represents a single digit from the range 0 to 9 (0 represents a blank space): ");
                return Console.ReadLine();
            }

            bool IsManuallyLoadType() => input == ConsoleLoadBoardTypes.Manually.ToString();
            bool IsFromFileLoadType() => input == ConsoleLoadBoardTypes.From_file.ToString();
            bool IsYesAnswer() => input == YesOrNo.Yes.ToString();
            bool IsNoAnswer() => input == YesOrNo.No.ToString();        
        }
    }
}