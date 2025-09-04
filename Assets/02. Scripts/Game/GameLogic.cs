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
                firstPlayerState = new PlayerState(true);
                secondPlayerState = new AIState();

                SetState(firstPlayerState);
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
    public Constants.PlayerType[,] GetBoard() { return _board; }

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
        SetState(null);
        firstPlayerState = null;
        secondPlayerState = null;

        GameManager.Instance.OpenConfirmPanel("게임오버", () =>
        {
            GameManager.Instance.ChangeToMainScene();
        });
    }

    // 게임의 결과를 확인 하는 함수
    public GameResult CheckGameResult()
    {
        if(TicTacToeAI.CheckGameWin(Constants.PlayerType.PlayerA, _board))
        {
            return GameResult.Win;
        }
        if(TicTacToeAI.CheckGameWin(Constants.PlayerType.PlayerB, _board))
        {
            return GameResult.Lose;
        }

        if(TicTacToeAI.CheckGameDraw(_board))
        {
            return GameResult.Draw;
        }


        return GameResult.None;
    }

}
