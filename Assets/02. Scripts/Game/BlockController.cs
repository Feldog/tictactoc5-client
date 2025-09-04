using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blocks;

    public delegate void OnBlockClicked(int row, int col);
    public OnBlockClicked onBlockClickedDelegate;

    private void Start()
    {
        InitBlocks();
    }

    // 1. 모든 블럭을 초기화
    public void InitBlocks()
    {
        for(int i = 0; i < blocks.Length; i++)
        {
            blocks[i].InitMarker(i, blockIndex =>
            {
                var row = blockIndex / Constants.BlockColumnConunt;
                var col = blockIndex % Constants.BlockColumnConunt;

                onBlockClickedDelegate?.Invoke(row, col);
            });
        }
    }
    // 2. 특정 블럭에 마커 표시
    public void PlaceMarker(Block.MarkerType markerType, int row, int col)
    {
        var blockIndex = row * Constants.BlockColumnConunt + col;

        blocks[blockIndex].SetMarker(markerType);
    }

    // 3. 특정 블럭의 배경색을 설정
    public void SetBlockColor()
    {
        // TODO: 게임 로직이 완성되면 구현
    }
}
