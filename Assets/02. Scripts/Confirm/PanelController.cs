using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class PanelController : MonoBehaviour
{
    private CanvasGroup _backgroundCanvasGroup;

    // �˾�â RectTransform
    [SerializeField] private RectTransform panelRectTransform;

    private void Awake()
    {
        _backgroundCanvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// Panel ǥ��
    /// </summary>
    public void Show()
    {
        _backgroundCanvasGroup.alpha = 0f;
        panelRectTransform.localScale = Vector3.zero;

        _backgroundCanvasGroup.DOFade(1f, 0.3f).SetEase(Ease.Linear);
        panelRectTransform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
    }

    /// <summary>
    /// Panel �����
    /// </summary>
    public void Hide()
    {
        _backgroundCanvasGroup.alpha = 1f;
        panelRectTransform.localScale = Vector3.one;

        _backgroundCanvasGroup.DOFade(0f, 0.3f).SetEase(Ease.Linear);
        panelRectTransform.DOScale(0f, 0.3f).SetEase(Ease.InBack);
    }
}
