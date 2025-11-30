using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter board size: ");
        int size = int.Parse(Console.ReadLine() ?? "10");

        Console.Write("Enter difficulty (1 = Easy, 2 = Medium, 3 = Hard): ");
        int diffNum = int.Parse(Console.ReadLine() ?? "1");

        DifficultyLevel diff = diffNum switch
        {
            1 => DifficultyLevel.Easy,
            2 => DifficultyLevel.Medium,
            3 => DifficultyLevel.Hard,
            _ => DifficultyLevel.Easy
        };

        BoardModel board = new BoardModel(size, diff);
        BoardService service = new BoardService();

        service.SetupBombs(board);
        service.CountBombsNearby(board);

        PrintAnswers(board);

        Console.WriteLine();
        Console.WriteLine("Done.");
    }

    private static void PrintAnswers(BoardModel board)
    {
        Console.WriteLine("\nANSWER KEY:\n");

        Console.Write("    ");
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write($"{col,2} ");
        }
        Console.WriteLine();

        Console.Write("   ");
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write("---");
        }
        Console.WriteLine();

        for (int row = 0; row < board.Size; row++)
        {
            Console.Write($"{row,2}|");

            for (int col = 0; col < board.Size; col++)
            {
                var cell = board.Cells[row, col];

                if (cell.IsBomb)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" B ");
                }
                else if (cell.NumberOfBombNeighbors > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($" {cell.NumberOfBombNeighbors} ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" . ");
                }

                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}