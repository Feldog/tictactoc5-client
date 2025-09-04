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
    /// Confirm Panel�� ǥ���ϴ� �޼���
    /// </summary>
    public void Show(string message, OnConfirmButtonClicked onConfirmButtonClicked)
    {
        messageText.text = message;
        _onConfirmButtonClicked = onConfirmButtonClicked;
        base.Show();
    }

    /// <summary>
    /// Ȯ�� ��ư�� ��������
    /// </summary>
    public void OnClickConfirmButton()
    {
        base.Hide( () => _onConfirmButtonClicked?.Invoke() );
    }

    /// <summary>
    /// X ��ư ��������
    /// </summary>
    public void OnClickCloseButton()
    {
        base.Hide();
    }
}
