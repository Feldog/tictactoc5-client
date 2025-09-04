using UnityEngine;

public class PlayerState : BasePlayerState
{
    private bool _IsFirstPlayer;
    private Constants.PlayerType _playerType;

    public PlayerState(bool isFirstPlayer)
    {
        _IsFirstPlayer = isFirstPlayer;
        _playerType = _IsFirstPlayer ? Constants.PlayerType.PlayerA : Constants.PlayerType.PlayerB;
    }

    #region 필수 메서드
    public override void HandleMove(GameLogic gameLogic, int row, int col)
    {
        ProcessMove(gameLogic,_playerType, row, col);
    }

    public override void OnEnter(GameLogic gameLogic)
    {
        // 1. First Player인지 확인해서 게임 Ui에 현재 턴 표시
        if (_IsFirstPlayer)
        {
            GameManager.Instance.SetGameTurnPanel(GameUIController.GameTurnPanelType.ATurn);
        }
        else
        {
            GameManager.Instance.SetGameTurnPanel(GameUIController.GameTurnPanelType.BTurn);
        }

            // 2. Block Controller에게 해야 할 일을 전달
            gameLogic.blockController.onBlockClickedDelegate = (row, col) =>
            {
                // Block이 터치 될 때까지 기다렸다가
                // 터치가 되면 처리할 일

                gameLogic.SetNewBoardValue(_playerType, row, col);
                HandleMove(gameLogic, row, col);
            };
    }

    public override void OnExit(GameLogic gameLogic)
    {
        gameLogic.blockController.onBlockClickedDelegate = null;
    }

    protected override void HandleNextTurn(GameLogic gameLogic)
    {
        if (_IsFirstPlayer)
        {
            gameLogic.SetState(gameLogic.secondPlayerState);
        }
        else
        {
            gameLogic.SetState(gameLogic.firstPlayerState);
        }
    }
    #endregion

}
