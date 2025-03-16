namespace Challenge;
internal class NQueen {
    static void Main (string[] args) {
        var chessBoard = new char[4, 4];
        while (QueenNxtColPos != 4) {
            QueenSideMovement (chessBoard, RowPos, ColPos);
            QueenBobMovement (chessBoard, RowPos, ColPos);
            QueenDiagRightMovement (chessBoard, RowPos, ColPos);
            QueenDiagLeftMovement (chessBoard, RowPos, ColPos);
            PrintChessBoard (chessBoard);
            FindQueenNxtPos (chessBoard, RowPos);
        }
    }

    static void QueenSideMovement (char[,] arr, byte row, byte col) {
        arr[row, col] = 'Q';
        byte tempCol = col;
        while (++col % 4 != tempCol) arr[row, col] = 'x';
        ColPos = col %= 4;
    }

    static void QueenBobMovement (char[,] arr, byte row, byte col) {
        byte tempRow = row;
        while (++row % 4 != tempRow) arr[row, col] = 'x';
        RowPos = row %= 4;
    }

    static void QueenDiagRightMovement (char[,] arr, byte row, byte col) {
        byte tempRow = row, tempCol = col;
        while (++row % 4 != tempRow & ++col % 4 != tempCol) arr[row, col] = 'x';
        RowPos = row %= 4; ColPos = col %= 4;
    }

    static void QueenDiagLeftMovement (char[,] arr, byte row, byte col) {
        byte tempRow = row, tempCol = col;
        while (++row % 4 != tempRow & ++col % 4 != tempCol) arr[row, col] = 'x';
        RowPos = row %= 4; ColPos = col %= 4;
    }

    static void FindQueenNxtPos (char[,] arr, byte row) {
        for (byte i = ++row; i < arr.GetLength (0); i++) {
            for (byte j = 0; j < arr.GetLength (1); j++) {
                if (arr[i, j] == '\0') {
                    (RowPos, ColPos) = (i, j);
                    return;
                }
            }
        }
    }

    static void PrintChessBoard (char[,] arr) {
        int counter = 0;
        foreach (var a in arr) {
            Console.Write (a + " ");
            if (++counter % 4 == 0) Console.WriteLine ();
        }
    }

    static byte QueenNxtRowPos = 0, QueenNxtColPos = 0, RowPos = 0, ColPos = 0;
}
