using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private Sprite oSprite;
    [SerializeField] private Sprite xSprite;
    [SerializeField] private SpriteRenderer markerSpriteRenderer;

    public delegate void OnBlockClicked(int index);
    private OnBlockClicked _onBlockClicked;

    public enum MarkerType { None, O, X }

    // Block Index
    private int _blockIndex;

    // Block의 색상 변경을 위한 Sprite Renderer
    private SpriteRenderer _spriteRenderer;
    private Color _defaultBlockColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultBlockColor = _spriteRenderer.color;
    }

    // 1. 초기화
    public void InitMarker(int blockIndex, OnBlockClicked onBlockClicked)
    {
        _blockIndex = blockIndex;
        SetMarker(MarkerType.None);
        SetBlockColor(_defaultBlockColor);
        _onBlockClicked = onBlockClicked;
    }

    // 2. 마커 설정
    public void SetMarker(MarkerType markerType)
    {
        Debug.Log(markerType.ToString());
        switch(markerType)
        {
            case MarkerType.None:
                markerSpriteRenderer.sprite = null;
                break;
            case MarkerType.X:
                markerSpriteRenderer.sprite = xSprite;
                break;
            case MarkerType.O:
                markerSpriteRenderer.sprite = oSprite;
                break;
        }
    }

    // 3. Block 배경 색상 변경
    public void SetBlockColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    // 4. 마우스 이벤트
    private void OnMouseUpAsButton()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        _onBlockClicked?.Invoke(_blockIndex);
    }
}
