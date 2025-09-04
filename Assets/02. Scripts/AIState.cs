using UnityEngine;

public class AIState : BasePlayerState
{
    public override void HandleMove(GameLogic gameLogic, int row, int col)
    {
        ProcessMove(gameLogic ,Constants.PlayerType.PlayerB, row, col);
    }

    public override void OnEnter(GameLogic gameLogic)
    {
        var board = gameLogic.GetBoard();

        var result = TicTacToeAI.GetBestMove(board);

        if(result.HasValue)
        {
            HandleMove(gameLogic, result.Value.row, result.Value.col);
        }
        else
        {
            gameLogic.EndGame(GameLogic.GameResult.Draw);
        }
    }

    public override void OnExit(GameLogic gameLogic)
    {
        
    }

    protected override void HandleNextTurn(GameLogic gameLogic)
    {
        gameLogic.SetState(gameLogic.firstPlayerState);
    }


}
