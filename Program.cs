namespace Challenge;
internal class Program {
    static void Main (string[] args) {
        Console.Write ("Enter the number: ");
        var ip = Console.ReadLine ();
        if (!string.IsNullOrEmpty (ip) && int.TryParse (ip, out int n)) {
            if (n == 1) { Console.WriteLine ("1"); return; }
            int noOfElem = n + (n - 1), center = noOfElem / 2; // or 2n - 1
            var arr = new int[noOfElem, noOfElem];
            int corLeftTopRow = 0, corLeftTopCol = 0, corRightTopRow = 0, corRightTopCol = noOfElem - 1,
                corRightBotRow = noOfElem - 1, corRightBotCol = noOfElem - 1,
                corLeftBotRow = noOfElem - 1, corLeftBotCol = 0;
            for (int i = 0; i < center; i++, n--, noOfElem--) {
                LeftToRight (arr, corLeftTopRow, corLeftTopCol, n, noOfElem);
                RightToBottom (arr, corRightTopRow, corRightTopCol, n, noOfElem);
                BottomToLeft (arr, corRightBotRow, corRightBotCol, n, i);
                LeftToUp (arr, corLeftBotRow, corLeftBotCol, n, i);
                // diagonal left to bottom
                corLeftTopRow = ++corLeftTopCol; corRightBotRow = --corRightBotCol;
                // diagonal right to bottom
                corRightTopRow++; corRightTopCol--;
                corLeftBotRow--; corLeftBotCol++;
            }
            arr[center, center] = 1;
            for (int i = 0; i < arr.GetLength (0); i++) {
                for (int j = 0; j < arr.GetLength (1); j++)
                    Console.Write (arr[i, j] + " ");
                Console.WriteLine ();
            }
        } else Console.WriteLine ("Invalid input");
    }

    static void LeftToRight (int[,] arr, int row, int col, int num, int breaker) {
        while (col != breaker)
            arr[row, col++] = num;
    }

    static void RightToBottom (int[,] arr, int row, int col, int num, int breaker) {
        while (++row != breaker)
            arr[row, col] = num;
    }

    static void BottomToLeft (int[,] arr, int row, int col, int num, int breaker) {
        while (--col != (breaker - 1))
            arr[row, col] = num;
    }

    static void LeftToUp (int[,] arr, int row, int col, int num, int breaker) {
        while (--row != breaker)
            arr[row, col] = num;
    }
}