using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConfirmPanelController : PanelController
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private Button confirmButton;
    
    public delegate void OnConfirmButtonClicked();
    private OnConfirmButtonClicked _onConfirmButtonClicked;

    /// <summary>
    /// Confirm Panel을 표시하는 메서드
    /// </summary>
    public void Show(string message, OnConfirmButtonClicked onConfirmButtonClicked)
    {
        messageText.text = message;
        _onConfirmButtonClicked = onConfirmButtonClicked;
        base.Show();
    }

    /// <summary>
    /// 확인 버튼을 눌렀을때
    /// </summary>
    public void OnClickConfirmButton()
    {
        base.Hide( () => _onConfirmButtonClicked?.Invoke() );
    }

    /// <summary>
    /// X 버튼 눌렀을때
    /// </summary>
    public void OnClickCloseButton()
    {
        base.Hide();
    }
}
