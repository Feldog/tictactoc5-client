using UnityEngine;

public class MainPanelController : MonoBehaviour
{
    public void OnClickSinglePlayerButton()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.SinglePlay);
    }

    public void OnClickDualPlayButton()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.DualPlay);
    }

    public void OnClickMultiPlayerButton()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.MultiPlay);
    }

    public void OnClickSettingButton()
    {

    }
}
