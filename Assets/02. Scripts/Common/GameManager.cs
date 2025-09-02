using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject confirmPanel;

    private Constants.GameType _gameType;

    // Panel�� ���� ���� Canvas ����
    private Canvas _canvas;

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
    public void OpenConfirmPanel(string message, UnityAction action)
    {
        if(_canvas != null)
        {
            var confirmPanelObject = Instantiate(confirmPanel, _canvas.transform);
            confirmPanelObject.GetComponent<ConfirmPanelController>().Show("������ �����Ͻðڽ��ϱ�?", action);
        }
    }

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        _canvas = FindFirstObjectByType<Canvas>();
    }

}
