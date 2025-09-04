using UnityEngine;

public class GameLogic
{
    public BlockController blockController;
    private Constants.PlayerType[,] _board;

    public BasePlayerState firstPlayerState;
    public BasePlayerState secondPlayerState;
    private BasePlayerState _currentPlayerState;

    public enum GameResult
    {
        None, Win, Lose, Draw
    }

    public GameLogic(BlockController blockController, Constants.GameType gameType)
    {
        this.blockController = blockController;

        _board = new Constants.PlayerType[Constants.BlockColumnConunt, Constants.BlockColumnConunt];

        switch (gameType)
        {
            case Constants.GameType.SinglePlay:
                break;
            case Constants.GameType.DualPlay:
                firstPlayerState = new PlayerState(true);
                secondPlayerState = new PlayerState(false);

                SetState(firstPlayerState);
                break;
            case Constants.GameType.MultiPlay:
                break;
        }
    }

    // 턴이 바뀔 때, 기존 진행하던 상태를 Exit
    // 상태를 currentPlayerState에 할당하고
    // 이번 턴의 상태의 Enter 호출
    public void SetState(BasePlayerState state)
    {
        _currentPlayerState?.OnExit(this);
        _currentPlayerState = state;
        _currentPlayerState?.OnEnter(this);
    }

    // _board 배열에 새로운 marker를 지정
    public bool SetNewBoardValue(Constants.PlayerType playerType, int row, int col)
    {
        if (_board[row, col] != Constants.PlayerType.None) { return false; }

        if(playerType == Constants.PlayerType.PlayerA)
        {
            _board[row, col] = playerType;
            blockController.PlaceMarker(Block.MarkerType.O, row, col);
            return true;
        }
        else if(playerType == Constants.PlayerType.PlayerB)
        {
            _board[row, col] = playerType;
            blockController.PlaceMarker(Block.MarkerType.X, row, col);
            return true;
        }
        return false;
    }

    public void EndGame(GameResult gameResult)
    {
        // TODO: Game Logic 정리
        SetState(null);
        firstPlayerState = null;
        secondPlayerState = null;


        // TODO: 유저에게 Game Over 표시
        Debug.Log("<color=green> ### GAME OVER ### </color>");
    }

    // 게임의 결과를 확인 하는 함수
    public GameResult CheckGameResult()
    {
        if(CheckGameWin(Constants.PlayerType.PlayerA, _board))
        {
            return GameResult.Win;
        }
        if(CheckGameWin(Constants.PlayerType.PlayerB, _board))
        {
            return GameResult.Lose;
        }

        if(CheckGameDraw(_board))
        {
            return GameResult.Draw;
        }


        return GameResult.None;
    }

    private bool CheckGameWin(Constants.PlayerType playerType, Constants.PlayerType[,] board)
    {
        // Col 체크 후 일자면 True
        for (var row = 0; row < board.GetLength(0); row++)
        {
            if (board[row, 0] == playerType &&
                board[row, 1] == playerType &&
                board[row, 2] == playerType)
            {
                return true;
            }
        }
        // Row 체크 후 일자면 True
        for (var col = 0; col < board.GetLength(1); col++)
        {
            if (board[0, col] == playerType &&
                board[1, col] == playerType &&
                board[2, col] == playerType)
            {
                return true;
            }
        }
        // 대각선 체크 후 일자면 True
        if (board[0,0] == playerType &&
            board[1,1] == playerType &&
            board[2,2] == playerType)
        {
            return true;
        }

        if (board[0,2] == playerType &&
            board[1,1] == playerType &&
            board[2,0] == playerType)
        {
            return true;
        }

        return false;
    }
    private bool CheckGameDraw(Constants.PlayerType[,] board)
    {
        for(var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0;col < board.GetLength(1); col++)
            {
                if (board[row, col] == Constants.PlayerType.None) return false;
            }
        }

        return true;
    }
}
