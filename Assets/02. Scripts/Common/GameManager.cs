using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject confirmPanel;

    private Constants.GameType _gameType;

    // Panel을 띄우기 위한 Canvas 정보
    private Canvas _canvas;

    /// <summary>
    /// Main에서 Game Scene으로 전환시 호출될 메서드
    /// </summary>
    public void ChangeToGameScene(Constants.GameType gameType)
    {
        _gameType = gameType;
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Game에서 Main으로 호출될 메서드
    /// </summary>
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("Main");
    }


    /// <summary>
    /// Confirm Panel을 띄우는 메서드
    /// </summary>
    /// <param name="message"></param>
    public void OpenConfirmPanel(string message, UnityAction action)
    {
        if(_canvas != null)
        {
            var confirmPanelObject = Instantiate(confirmPanel, _canvas.transform);
            confirmPanelObject.GetComponent<ConfirmPanelController>().Show("게임을 종료하시겠습니까?", action);
        }
    }

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        _canvas = FindFirstObjectByType<Canvas>();
    }

}
