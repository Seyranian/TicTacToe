using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            PlayGame();
        }

        static void PrintBoard()
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} |");
            Console.WriteLine("-------------");
        }

        static bool CheckWin(char player)
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (board[i] == player && board[i + 1] == player && board[i + 2] == player)
                    return true;
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == player && board[i + 3] == player && board[i + 6] == player)
                    return true;
            }
            if ((board[0] == player && board[4] == player && board[8] == player) ||
                (board[2] == player && board[4] == player && board[6] == player))
            {
                return true;
            }

            return false;
        }
        static bool IsBoardFull()
        {
            foreach (char position in board)
            {
                if (position == ' ')
                    return false;
            }
            return true;
        }
        static void PlayGame()
        {
            while (true)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Player {currentPlayer}, enter your move (1-9): ");
                int position = int.Parse(Console.ReadLine()) - 1;

                if (position >= 0 && position < 9 && board[position] == ' ')
                {
                    board[position] = currentPlayer;

                    if (CheckWin(currentPlayer))
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break;
                    }
                    else if (IsBoardFull())
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine("It's a tie!");
                        break;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                    Console.ReadLine();
                }
            }
        }
    }
}
