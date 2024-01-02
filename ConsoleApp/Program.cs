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
            Console.WriteLine($"If you want to exit the application at any time just write the command '{stopProgramCommand}'!");
            string input = string.Empty;         

            while (IsNotExitCommand())
            {
                SelectLoadType();

                if (IsNotExitCommand())
                {
                    if (IsManuallyLoadType())
                    {
                        var board = CreateBoard();
                        bool printBoard = true;

                        while (true)
                        {
                            if (printBoard)
                            {
                                Console.WriteLine();
                                Printer.PrintBoard(board);
                                Console.WriteLine();
                            }

                            Console.WriteLine($"Is the board correct? {yesOrNoPossibleAnswers}: ");
                            input = Console.ReadLine();

                            if (IsNotExitCommand())
                            {
                                if (IsYesAnswer())
                                {
                                    var result = engine.SolveBoard(board);

                                    if (result.Successful)
                                    {
                                        Console.WriteLine(defaultSuccessMessage);
                                        Printer.PrintBoard(result.SolvedBoard, 50);
                                        Thread.Sleep(100);
                                    }
                                    else Console.WriteLine(defaultFailMessage);

                                    break;
                                }
                                else if (IsNoAnswer())
                                {
                                    while (true)
                                    {
                                        Console.WriteLine($"Would you like to start from scratch or edit specific row? '{ConsoleEditBoardTypes.Start_over}/{ConsoleEditBoardTypes.Specific_row}': ");
                                        input = Console.ReadLine();

                                        if (IsNotExitCommand())
                                        {
                                            if (input == ConsoleEditBoardTypes.Start_over.ToString())
                                            {
                                                board = CreateBoard();
                                                printBoard = true;
                                                break;
                                            }
                                            else if (input == ConsoleEditBoardTypes.Specific_row.ToString())
                                            {
                                                var rx = new Regex(consoleEditRowRegexPattern);
                                                while (true)
                                                {
                                                    input = EditRow();

                                                    while (true)
                                                    {
                                                        if (IsNotExitCommand() && rx.IsMatch(input))
                                                            break;

                                                        Console.WriteLine(invalidCommandMessage);
                                                        input = EditRow();
                                                    }

                                                    string[] editRowInput = input.Split(consoleEditRowDelimiter, StringSplitOptions.RemoveEmptyEntries).ToArray();
                                                    int rowNumber = int.Parse(editRowInput[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).First());
                                                    int[] rowValues = ParseRowValues(editRowInput[1]);

                                                    for (int i = 0; i < gridSize; i++)
                                                    {
                                                        board[rowNumber -1, i] = rowValues[i];
                                                    }
                                                    break;
                                                }
                                                printBoard = true;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(invalidCommandMessage);
                                                continue;
                                            }
                                        }
                                    }
                                    
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine(invalidCommandMessage);
                                    printBoard = false;
                                    continue;
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

            bool IsNotExitCommand()
            {
                if (input == stopProgramCommand)
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

                    if (IsNotExitCommand())
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

                for (int i = 0; i < gridSize; i++)
                {
                    input = ReadRow(i + 1);

                    while (true)
                    {
                        if (IsNotExitCommand() && rx.IsMatch(input))
                            break;

                        Console.WriteLine(invalidCommandMessage);
                        input = ReadRow(i + 1);
                    }

                    int[] rowValues = ParseRowValues(input);
                    for (int j = 0; j < gridSize; j++)
                    {
                        board[i, j] = rowValues[j];
                    }
                }
                return board;
            }

            int[] ParseRowValues(string rowValues)
            {
                return rowValues.Split(consoleReadRowDelimiter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            string ReadRow(int i)
            {
                Console.WriteLine($"Please enter values for row #{i} following the pattern '{consoleReadRowUIPattern}' where '#' represents a single digit from the range 0 to 9 (0 represents a blank space): ");
                return Console.ReadLine();
            }

            string EditRow()
            {
                Console.WriteLine($"Please enter the row number and row values following the pattern '{consoleEditRowUIPattern}' where '#' represents a single digit from the range 0 to 9 (0 represents a blank space): ");
                return Console.ReadLine();
            }

            bool IsManuallyLoadType() => input == ConsoleLoadBoardTypes.Manually.ToString();
            bool IsFromFileLoadType() => input == ConsoleLoadBoardTypes.From_file.ToString();
            bool IsYesAnswer() => input == YesOrNo.Yes.ToString();
            bool IsNoAnswer() => input == YesOrNo.No.ToString();        
        }
    }
}