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

    // 1. ��� ���� �ʱ�ȭ
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
    // 2. Ư�� ���� ��Ŀ ǥ��
    public void PlaceMarker(Block.MarkerType markerType, int row, int col)
    {
        var blockIndex = row * Constants.BlockColumnConunt + col;

        blocks[blockIndex].SetMarker(markerType);
    }

    // 3. Ư�� ���� ������ ����
    public void SetBlockColor()
    {
        // TODO: ���� ������ �ϼ��Ǹ� ����
    }
}
