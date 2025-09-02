using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConfirmPanelController : PanelController
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private Button confirmButton;

    /// <summary>
    /// Confirm Panel을 표시하는 메서드
    /// </summary>
    public void Show(string message, UnityAction action)
    {
        messageText.text = message;

        // Confirm 이벤트 추가
        confirmButton.onClick.AddListener(action);
        
        base.Show();
    }

    /// <summary>
    /// 확인 버튼을 눌렀을때
    /// </summary>
    public void OnClickConfirmButton()
    {
        base.Hide();
    }

    /// <summary>
    /// X 버튼 눌렀을때
    /// </summary>
    public void OnClickCloseButton()
    {
        base.Hide();
    }
}
