using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;

internal class Program
{
    /// <summary>
    /// Entry point for the console Minesweeper game.
    /// Milestone 2: creates the board, runs the game loop,
    /// and allows the player to visit or flag cells.
    /// </summary>
    static void Main(string[] args)
    {
        // --- Get board size from the user ---
        Console.Write("Enter board size: ");
        int size = int.Parse(Console.ReadLine() ?? "10");

        // --- Get difficulty level from the user ---
        Console.Write("Enter difficulty (1=Easy, 2=Medium, 3=Hard): ");
        int diffNum = int.Parse(Console.ReadLine() ?? "1");

        // Map numeric input to DifficultyLevel enum
        DifficultyLevel diff = diffNum switch
        {
            1 => DifficultyLevel.Easy,
            2 => DifficultyLevel.Medium,
            3 => DifficultyLevel.Hard,
            _ => DifficultyLevel.Easy
        };

        // --- Create the board and service objects ---
        BoardModel board = new BoardModel(size, diff);
        BoardService service = new BoardService();

        // Set up bombs and neighbor counts using the BLL
        service.SetupBombs(board);
        service.CountBombsNearby(board);

        // Print the full answer key for testing / debugging
        Console.WriteLine("Cheat Answer Board:");
        PrintAnswers(board);

        bool gameOver = false;

        // =========================
        //     MAIN GAME LOOP
        // =========================
        while (!gameOver)
        {
            // Show the player-facing board with ?, F, and numbers
            PrintBoard(board);

            // --- Get move from the player ---
            Console.Write("\nEnter row: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter col: ");
            int col = int.Parse(Console.ReadLine());

            Console.WriteLine("1 = Visit");
            Console.WriteLine("2 = Flag");
            Console.WriteLine("3 = Use Reward (not implemented)");
            Console.Write("Choose action: ");

            int choice = int.Parse(Console.ReadLine());

            // Call into the BoardService based on the action chosen
            if (choice == 1)
            {
                // Visit a cell
                service.VisitCell(board, row, col);
            }
            else if (choice == 2)
            {
                // Place or remove a flag
                service.ToggleFlag(board, row, col);
            }
            // choice 3 is reserved for a future reward feature

            // --- Update game state (InProgress, Won, Lost) ---
            board.GameState = service.DetermineGameState(board);

            if (board.GameState == GameState.Won)
            {
                Console.WriteLine("\nYOU WON!!!");
                gameOver = true;
            }
            else if (board.GameState == GameState.Lost)
            {
                Console.WriteLine("\nYOU HIT A BOMB!!!");
                gameOver = true;
            }
        }

        Console.WriteLine("Game over.");
    }

    /// <summary>
    /// Prints the full answer key to the console:
    /// bombs as B, neighbor counts as numbers, and dots for empty cells.
    /// This is mainly for debugging and verifying the board setup.
    /// </summary>
    private static void PrintAnswers(BoardModel board)
    {
        Console.WriteLine("\nANSWER KEY:\n");

        // Print column headers
        Console.Write("    ");
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write($"{col,2} ");
        }
        Console.WriteLine();

        // Print horizontal divider
        Console.Write("   ");
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write("---");
        }
        Console.WriteLine();

        // Print each row of the answer board
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

                // Reset color after each cell
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Prints the player-facing board:
    /// ? for hidden cells, F for flags, and numbers or bombs
    /// for cells that have been visited.
    /// </summary>
    private static void PrintBoard(BoardModel board)
    {
        Console.WriteLine("\nGAME BOARD:\n");

        // Print column headers
        Console.Write("    ");
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write($"{col,2} ");
        }
        Console.WriteLine();

        // Print horizontal divider
        Console.Write("   ");
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write("---");
        }
        Console.WriteLine();

        // Print each row of the game board
        for (int row = 0; row < board.Size; row++)
        {
            Console.Write($"{row,2}|");

            for (int col = 0; col < board.Size; col++)
            {
                var cell = board.Cells[row, col];

                if (cell.IsFlagged)
                {
                    // Flagged but not visited
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" F ");
                }
                else if (!cell.IsVisited)
                {
                    // Hidden cell
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" ? ");
                }
                else if (cell.IsBomb)
                {
                    // Visited bomb (game over)
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" B ");
                }
                else if (cell.NumberOfBombNeighbors > 0)
                {
                    // Visited safe cell with neighboring bombs
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($" {cell.NumberOfBombNeighbors} ");
                }
                else
                {
                    // Visited safe cell with zero neighbors
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" . ");
                }

                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}