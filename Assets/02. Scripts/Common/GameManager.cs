using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject confirmPanel;

    private Constants.GameType _gameType;

    // Panel�� ���� ���� Canvas ����
    private Canvas _canvas;

    // confirmPanel ���� (Don't Destroy)
    private GameObject confirmPanelObject;

    // Game Logic
    private GameLogic _gameLogic;

    private GameUIController _gameUiConroller;

    /// <summary>
    /// Main���� Game Scene���� ��ȯ�� ȣ��� �޼���
    /// </summary>
    public void ChangeToGameScene(Constants.GameType gameType)
    {
        _gameType = gameType;
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Game���� Main���� ȣ��� �޼���
    /// </summary>
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("Main");
    }


    /// <summary>
    /// Confirm Panel�� ���� �޼���
    /// </summary>
    /// <param name="message"></param>
    public void OpenConfirmPanel(string message, ConfirmPanelController.OnConfirmButtonClicked onConfirmButtonClicked)
    {
        if(_canvas != null)
        {
            if (confirmPanelObject == null)
            {
                confirmPanelObject = Instantiate(confirmPanel, _canvas.transform);
            }

            confirmPanelObject.GetComponent<ConfirmPanelController>().Show("������ �����Ͻðڽ��ϱ�?", onConfirmButtonClicked);
        }
    }

    /// <summary>
    /// Game Scene���� ���� ǥ���ϴ� UI�� �����ϴ� �Լ�
    /// </summary>
    /// <param name="gameTurnPanelType">ǥ���� Turn ����</param>
    public void SetGameTurnPanel(GameUIController.GameTurnPanelType gameTurnPanelType)
    {
        _gameUiConroller.SetGameTurnPanel(gameTurnPanelType);
    }

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        _canvas = FindFirstObjectByType<Canvas>();

        if(scene.name == "Game")
        {
            // Block �ʱ�ȭ
            var blockController = FindFirstObjectByType<BlockController>();
            if (blockController != null)
            {
                blockController.InitBlocks();
            }
            else
            {
                // TODO: ���� �˾��� ǥ���ϰ� ������ ����
            }

            _gameUiConroller = FindFirstObjectByType<GameUIController>();
            if(_gameUiConroller != null)
            {
                _gameUiConroller.SetGameTurnPanel(GameUIController.GameTurnPanelType.None);
            }

            if(_gameLogic != null)
            {
                // ���� ������ ������ �Ҹ�
            }

            _gameLogic = new GameLogic(blockController, _gameType);
        }
    }

}
