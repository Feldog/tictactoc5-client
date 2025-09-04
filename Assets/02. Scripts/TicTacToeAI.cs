using UnityEngine;

public static class TicTacToeAI
{
    public static (int row, int col)? GetBestMove(Constants.PlayerType[,] board)
    {
        float bestScore = -1000;
        (int row, int col) movePostion = (-1, -1);

        for(var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                if (board[row,col] == Constants.PlayerType.None)
                {
                    board[row, col] = Constants.PlayerType.PlayerB;
                    var score = DoMiniMax(board, 0, false);
                    board[row, col] = Constants.PlayerType.None;
                    if(score > bestScore)
                    {
                        bestScore = score;
                        movePostion = (row, col);
                    }
                }
            }
        }
        if(movePostion != (-1, -1))
        {
            return (movePostion.row, movePostion.col);
        }

        return null;
    }

    public static float DoMiniMax(Constants.PlayerType[,] board, int depth, bool isMaxmizing)
    {

        if(CheckGameWin(Constants.PlayerType.PlayerA, board))
            return -10 + depth;
        if(CheckGameWin(Constants.PlayerType.PlayerB, board))
            return 10 - depth;
        if(CheckGameDraw(board))
            return 0;
        if (isMaxmizing)
        {
            var bestScore = float.MinValue;
            for (var row = 0; row < board.GetLength(0); row++)
            {
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == Constants.PlayerType.None)
                    {
                        board[row, col] = Constants.PlayerType.PlayerB;
                        var score = DoMiniMax(board, depth + 1, false);
                        board[row, col] = Constants.PlayerType.None;
                        bestScore = Mathf.Max(bestScore, score);
                    }
                }
            }
            return bestScore;
        }
        else
        {
            var bestScore = float.MaxValue;
            for (var row = 0; row < board.GetLength(0); row++)
            {
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == Constants.PlayerType.None)
                    {
                        board[row, col] = Constants.PlayerType.PlayerA;
                        var score = DoMiniMax(board, depth + 1, true);
                        board[row, col] = Constants.PlayerType.None;
                        bestScore = Mathf.Min(bestScore, score);
                    }
                }
            }
            return bestScore;
        }
    }

    public static bool CheckGameWin(Constants.PlayerType playerType, Constants.PlayerType[,] board)
    {
        // Col üũ �� ���ڸ� True
        for (var row = 0; row < board.GetLength(0); row++)
        {
            if (board[row, 0] == playerType &&
                board[row, 1] == playerType &&
                board[row, 2] == playerType)
            {
                return true;
            }
        }
        // Row üũ �� ���ڸ� True
        for (var col = 0; col < board.GetLength(1); col++)
        {
            if (board[0, col] == playerType &&
                board[1, col] == playerType &&
                board[2, col] == playerType)
            {
                return true;
            }
        }
        // �밢�� üũ �� ���ڸ� True
        if (board[0, 0] == playerType &&
            board[1, 1] == playerType &&
            board[2, 2] == playerType)
        {
            return true;
        }

        if (board[0, 2] == playerType &&
            board[1, 1] == playerType &&
            board[2, 0] == playerType)
        {
            return true;
        }

        return false;
    }
    public static bool CheckGameDraw(Constants.PlayerType[,] board)
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == Constants.PlayerType.None) return false;
            }
        }

        return true;
    }
}
