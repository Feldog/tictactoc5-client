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

    #region �ʼ� �޼���
    public override void HandleMove(GameLogic gameLogic, int row, int col)
    {
        ProcessMove(gameLogic,_playerType, row, col);
    }

    public override void OnEnter(GameLogic gameLogic)
    {
        // 1. First Player���� Ȯ���ؼ� ���� Ui�� ���� �� ǥ��
        if (_IsFirstPlayer)
        {
            GameManager.Instance.SetGameTurnPanel(GameUIController.GameTurnPanelType.ATurn);
        }
        else
        {
            GameManager.Instance.SetGameTurnPanel(GameUIController.GameTurnPanelType.BTurn);
        }

            // 2. Block Controller���� �ؾ� �� ���� ����
            gameLogic.blockController.onBlockClickedDelegate = (row, col) =>
            {
                // Block�� ��ġ �� ������ ��ٷȴٰ�
                // ��ġ�� �Ǹ� ó���� ��

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
