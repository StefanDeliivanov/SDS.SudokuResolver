namespace SDS.SudokuResolver.Core.Setup
{
    public static class Settings
    {
        public const int gridSize = 9;
        public const string defaultSuccessMessage = "Board solved successfully!";
        public const string defaultFailMessage = "Board is unsolvable!";

        public class ConsoleAppConstants
        {
            public const string stopProgramCommand = "Exit";
            public const string invalidCommandMessage = "Invalid command!";
            public static string yesOrNoPossibleAnswers = $"'{YesOrNo.Yes}/{YesOrNo.No}'";

            public const char emptySpace = ' ';
            public const char dash = '-';
            public const char verticalBar = '|';
            public const string consoleReadRowDelimiter = ", ";

            public static readonly string defaultSpace = new string(emptySpace, 2);
            public static readonly string rowDelimiter = emptySpace + new string(dash, 35);
            public static readonly string columnDelimiter = defaultSpace + verticalBar + defaultSpace;
            public static readonly string startColumnDelimiter = verticalBar.ToString();
            public static readonly string endColumnDelimiter = defaultSpace + verticalBar;
            public static readonly string numbersDelimiter = defaultSpace;
            public static readonly string consoleReadRowRegexPattern = @"^\d, \d, \d, \d, \d, \d, \d, \d, \d$";
            public static readonly string consoleReadRowUIPattern = string.Join(consoleReadRowDelimiter, new string('#', 9).ToCharArray());

            public enum ConsoleLoadBoardTypes
            {
                From_file,
                Manually
            }

            public enum YesOrNo
            {
                Yes,
                No
            }

            public class AsciiArt
            {

                // Font Name: Shimrod
                public const string welcomeTextShimrod = @"
                      =====================================================================
                    ||               ,   .     .                     .                     ||                
                    ||               | . |     |                     |                     ||                
                    ||               | ) ) ,-. | ,-. ,-. ;-.-. ,-.   |-  ,-.               ||                
                    ||               |/|/  |-' | |   | | | | | |-'   |   | |               ||                
                    ||               ' '   `-' ' `-' `-' ' ' ' `-'   `-' `-'               ||                      
                    ||      ,-.        .     ,          ,-.              .                 ||
                    ||     (   `       |     |          |  )             |                 ||
                    ||      `-.  . . ,-| ,-. | , . .    |-<  ,-. ,-. ,-. | . , ,-. ;-.     ||
                    ||     .   ) | | | | | | |<  | |    |  \ |-' `-. | | | |/  |-' |       ||
                    ||      `-'  `-` `-' `-' ' ` `-`    '  ' `-' `-' `-' ' '   `-' '       ||
                      =====================================================================
                ";

                // Font Name: Big Money-sw
                public const string welcomeTexBigMoney_sw = @"
                      ==================================================================================================================================================
                    ||                          __       __            __                                                     __                                        ||
                    ||                         /  |  _  /  |          /  |                                                   /  |                                       ||
                    ||                         $$ | / \ $$ |  ______  $$ |  _______   ______   _____  ____    ______        _$$ |_     ______                           ||
                    ||                         $$ |/$  \$$ | /      \ $$ | /       | /      \ /     \/    \  /      \      / $$   |   /      \                          ||
                    ||                         $$ /$$$  $$ |/$$$$$$  |$$ |/$$$$$$$/ /$$$$$$  |$$$$$$ $$$$  |/$$$$$$  |     $$$$$$/   /$$$$$$  |                         ||                                              
                    ||                         $$ $$/$$ $$ |$$    $$ |$$ |$$ |      $$ |  $$ |$$ | $$ | $$ |$$    $$ |       $$ | __ $$ |  $$ |                         ||
                    ||                         $$$$/  $$$$ |$$$$$$$$/ $$ |$$ \_____ $$ \__$$ |$$ | $$ | $$ |$$$$$$$$/        $$ |/  |$$ \__$$ |                         ||
                    ||                         $$$/    $$$ |$$       |$$ |$$       |$$    $$/ $$ | $$ | $$ |$$       |       $$  $$/ $$    $$/                          ||
                    ||                         $$/      $$/  $$$$$$$/ $$/  $$$$$$$/  $$$$$$/  $$/  $$/  $$/  $$$$$$$/         $$$$/   $$$$$$/                           ||                                                
                    ||                                                                                                                                                  ||
                    ||                                                                                                                                                  ||
                    ||                                                                                                                                                  ||
                    ||                                                                                                                                                  ||
                    ||     ______                   __            __                        _______                                 __                                  ||
                    ||    /      \                 /  |          /  |                      /       \                               /  |                                 ||
                    ||   /$$$$$$  | __    __   ____$$ |  ______  $$ |   __  __    __       $$$$$$$  |  ______    _______   ______  $$ | __     __  ______    ______     ||
                    ||   $$ \__$$/ /  |  /  | /    $$ | /      \ $$ |  /  |/  |  /  |      $$ |__$$ | /      \  /       | /      \ $$ |/  \   /  |/      \  /      \    ||
                    ||   $$      \ $$ |  $$ |/$$$$$$$ |/$$$$$$  |$$ |_/$$/ $$ |  $$ |      $$    $$< /$$$$$$  |/$$$$$$$/ /$$$$$$  |$$ |$$  \ /$$//$$$$$$  |/$$$$$$  |   ||
                    ||    $$$$$$  |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$   $$<  $$ |  $$ |      $$$$$$$  |$$    $$ |$$      \ $$ |  $$ |$$ | $$  /$$/ $$    $$ |$$ |  $$/    ||
                    ||   /  \__$$ |$$ \__$$ |$$ \__$$ |$$ \__$$ |$$$$$$  \ $$ \__$$ |      $$ |  $$ |$$$$$$$$/  $$$$$$  |$$ \__$$ |$$ |  $$ $$/  $$$$$$$$/ $$ |         ||
                    ||   $$    $$/ $$    $$/ $$    $$ |$$    $$/ $$ | $$  |$$    $$/       $$ |  $$ |$$       |/     $$/ $$    $$/ $$ |   $$$/   $$       |$$ |         ||
                    ||    $$$$$$/   $$$$$$/   $$$$$$$/  $$$$$$/  $$/   $$/  $$$$$$/        $$/   $$/  $$$$$$$/ $$$$$$$/   $$$$$$/  $$/     $/     $$$$$$$/ $$/          ||
                      ==================================================================================================================================================
                ";

            }
        }
    }
}