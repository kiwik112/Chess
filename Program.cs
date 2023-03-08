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
                if (turn) Console.WriteLine("\nBlack's turn > ");
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
                int x1 = (int)parts[0] - (int)'a';
                int y1 = 7 - ((int)parts[1] - (int)'1');
                int x2 = (int)parts[2] - (int)'a';
                int y2 = 7 - ((int)parts[3] - (int)'1');
                Debug.WriteLine($"{y1}, {x1} to {y2}, {x2}");
                board[y2, x2] = board[y1, x1];
                board[y1, x1] = 0;
                err = false;
            }
        }
        static void Draw()
        {
            Console.Clear();
            Console.WriteLine("Chess by Pavel\n");
            Console.WriteLine("    a   b   c   d   e   f   g   h");
            Console.WriteLine("  ---------------------------------");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"{8 - i} | {pieces[board[i, 0]]} | {pieces[board[i, 1]]} | {pieces[board[i, 2]]} | {pieces[board[i, 3]]} | {pieces[board[i, 4]]} | {pieces[board[i, 5]]} | {pieces[board[i, 6]]} | {pieces[board[i, 7]]} | {8 - i}");
                Console.WriteLine("  ---------------------------------");
            }
            Console.WriteLine("    a   b   c   d   e   f   g   h");
        }
    }
}