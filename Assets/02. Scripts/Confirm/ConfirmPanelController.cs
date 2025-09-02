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
    /// Confirm Panel�� ǥ���ϴ� �޼���
    /// </summary>
    public void Show(string message, UnityAction action)
    {
        messageText.text = message;

        // Confirm �̺�Ʈ �߰�
        confirmButton.onClick.AddListener(action);
        
        base.Show();
    }

    /// <summary>
    /// Ȯ�� ��ư�� ��������
    /// </summary>
    public void OnClickConfirmButton()
    {
        base.Hide();
    }

    /// <summary>
    /// X ��ư ��������
    /// </summary>
    public void OnClickCloseButton()
    {
        base.Hide();
    }
}
