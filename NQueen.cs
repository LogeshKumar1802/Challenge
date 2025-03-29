namespace Challenge;
internal class NQueen {
    static void Main (string[] args) {
        while (Breaker) {
            ChessBoardMaker (RowPos, ColPos);
            FindQueenNxtPos (ChessBoard, RowPos);
        }
        PrintChessBoard ();
    }

    static void ChessBoardMaker (int rowPos, int colPos) {
        QueenSideMovement (ChessBoard, rowPos, colPos);
        QueenBobMovement (ChessBoard, rowPos, colPos);
        QueenDiaRightUMovement (ChessBoard, rowPos, colPos);
        QueenDiagRightDMovement (ChessBoard, rowPos, colPos);
        QueenDiaLeftUMovement (ChessBoard, rowPos, colPos);
        QueenDiagLeftDMovement (ChessBoard, rowPos, colPos);
    }

    static void QueenSideMovement (char[,] arr, int row, int col) {
        arr[row, col] = 'Q';
        int tempCol = col;
        while ((col = (++col) % NoOfQueens) != tempCol) arr[row, col] = 'x';
    }

    static void QueenBobMovement (char[,] arr, int row, int col) {
        int tempRow = row;
        while ((row = ++row % NoOfQueens) != tempRow) arr[row, col] = 'x';
    }

    static void QueenDiaRightUMovement (char[,] arr, int row, int col) {
        while (--row >= 0 & ++col < NoOfQueens) arr[row, col] = 'x';
    }

    static void QueenDiagRightDMovement (char[,] arr, int row, int col) {
        while (++row < NoOfQueens & ++col < NoOfQueens) arr[row, col] = 'x';
    }

    static void QueenDiaLeftUMovement (char[,] arr, int row, int col) {
        while (--row >= 0 & --col >= 0) arr[row, col] = 'x';
    }

    static void QueenDiagLeftDMovement (char[,] arr, int row, int col) {
        while (++row < NoOfQueens & --col >= 0) arr[row, col] = 'x';
    }

    static void FindQueenNxtPos (char[,] arr, int row) {
        for (int i = ++row; i < arr.GetLength (0); i++) {
            for (int j = 0; j < arr.GetLength (1); j++) {
                if (arr[i, j] == '\0') {
                    (RowPos, ColPos) = (i, j);
                    return;
                }
            }
        }
        if ((ColPos = ++QueenNxtColPos % NoOfQueens) == 0) ++QueenNxtRowPos;
        RowPos = QueenNxtRowPos;
        if (RowPos != 0) FindEmptyPosition (arr);
        if (RowPos == NoOfQueens) Breaker = false;
        QueensArr.Add (arr);
        ChessBoard = new char[NoOfQueens, NoOfQueens];
    }

    static void FindEmptyPosition (char[,] arr) {
        for (int i = 0; i < arr.GetLength (0); i++) {
            for (int j = 0; j < arr.GetLength (1); j++) {
                if (arr[i, j] == '\0') {
                    ChessBoardMaker (i, j);
                }
            }
        }
    }

    static void PrintChessBoard () {
        int counter = 0;
        foreach (var arr in QueensArr) {
            foreach (var a in arr) {
                Console.Write (a + " ");
                if (++counter % NoOfQueens == 0) Console.WriteLine ();
            }
            Console.WriteLine (new string ('-', Console.WindowWidth));
        }
    }

    static int QueenNxtRowPos = 0, QueenNxtColPos = 0, RowPos = 0, ColPos = 0;
    static readonly byte NoOfQueens = 4;
    static char[,] ChessBoard = new char[NoOfQueens, NoOfQueens];
    static List<char[,]> QueensArr = [];
    static bool Breaker = true;
}
