using System.Diagnostics;

namespace Ches
{
    internal class Program
    {
                                //0    1     2     3    4     5     6   |   7    8     9    10    11   12
        static char[] pieces = { ' ', 'P', 'N', 'B', 'R', 'Q', 'K', 'p', 'n', 'b', 'r', 'q', 'k' };
        static byte[,] defaultBoard =
        {
            { 10, 8, 9, 11, 12, 9, 8, 10 },
            { 7, 7, 7, 7, 7, 7, 7, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 4, 2, 3, 5, 6, 3, 2, 4 }
        };
        static byte[,] board =
        {
            { 10, 8, 9, 11, 12, 9, 8, 10 },
            { 7, 7, 7, 7, 7, 7, 7, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 4, 2, 3, 5, 6, 3, 2, 4 }
        };
        static bool err = false;
        static bool turn = false;
        static void Main(string[] args)
        {
            while (true)
            {
                Draw();
                if (err) Console.WriteLine("u done messed up fam");
                err = true;

                if (turn) Console.Write("\nBlack's turn > ");
                else Console.Write("\nWhite's turn > ");
                string? input = Console.ReadLine();
                if (input == null) continue;
                switch (input)
                {
                    case "r":
                        board = defaultBoard;
                        err = false;
                        continue;
                    case "q":
                        Environment.Exit(0);
                        break;
                }

                char[] parts = input.ToCharArray();
                if (parts.Length != 4) continue;
                if (parts[0] < 'a' || parts[0] > 'h' || parts[1] < '1' || parts[1] > '8' || parts[2] < 'a' || parts[2] > 'h' || parts[3] < '1' || parts[3] > '8') continue;

                byte x1 = (byte)(parts[0] - 'a');
                byte y1 = (byte)(7 - (parts[1] - '1'));
                byte x2 = (byte)(parts[2] - 'a');
                byte y2 = (byte)(7 - (parts[3] - '1'));

                if (IsIllegal(board, turn, x1, y1, x2, y2)) continue;

                if (board[y1, x1] == 0) continue;
                board[y2, x2] = board[y1, x1];
                board[y1, x1] = 0;

                err = false;
                turn = !turn;
            }
        }
        static void Draw()
        {
            Console.Clear();
            Console.WriteLine("Chess by Pavel\n");
            Console.WriteLine("    a   b   c   d   e   f   g   h");
            Console.WriteLine("  ---------------------------------");
            for (byte i = 0; i < 8; i++)
            {
                Console.WriteLine($"{8 - i} | {pieces[board[i, 0]]} | {pieces[board[i, 1]]} | {pieces[board[i, 2]]} | {pieces[board[i, 3]]} | {pieces[board[i, 4]]} | {pieces[board[i, 5]]} | {pieces[board[i, 6]]} | {pieces[board[i, 7]]} | {8 - i}");
                Console.WriteLine("  ---------------------------------");
            }
            Console.WriteLine("    a   b   c   d   e   f   g   h");
        }
        static bool IsIllegal(byte[,] board, bool turn, byte x1, byte y1, byte x2, byte y2)
        {
            bool illegal = false;

            if (board[y1, x1] > 6 ^ turn) illegal = true;
            if ((board[y2, x2] < 7 && board[y2, x2] > 0) ^ turn) illegal = true;

            return illegal;
        }
    }
}