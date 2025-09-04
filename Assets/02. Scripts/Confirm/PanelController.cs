using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class PanelController : MonoBehaviour
{
    private CanvasGroup _backgroundCanvasGroup;

    // 팝업창 RectTransform
    [SerializeField] private RectTransform panelRectTransform;

    // Panel이 Hide 될때 해야 할 동작
    public delegate void PanelConrollerHideDelegate();

    private void Awake()
    {
        _backgroundCanvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// Panel 표시
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);

        _backgroundCanvasGroup.alpha = 0f;
        panelRectTransform.localScale = Vector3.zero;

        _backgroundCanvasGroup.DOFade(1f, 0.3f).SetEase(Ease.Linear);
        panelRectTransform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
    }

    /// <summary>
    /// Panel 숨기기
    /// </summary>
    public void Hide(PanelConrollerHideDelegate hideDelegate = null)
    {
        _backgroundCanvasGroup.alpha = 1f;
        panelRectTransform.localScale = Vector3.one;

        _backgroundCanvasGroup.DOFade(0f, 0.3f).SetEase(Ease.Linear);
        panelRectTransform.DOScale(0f, 0.3f)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                hideDelegate?.Invoke();
                gameObject.SetActive(false);
            });
    }
}
