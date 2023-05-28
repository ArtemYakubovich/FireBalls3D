using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;

    private float _multiplierSizeBlock = 10f;

    private List<Block> _blocks;

    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform currentPoint = _buildPoint;
        
        for (int i = 0; i < _towerSize; i++)
        {
            Block tmpBlock = BuildBlock(currentPoint);
            _blocks.Add(tmpBlock);
            currentPoint = tmpBlock.transform;
        }

        return _blocks;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuidPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuidPoint(Transform currentSegment)
    {
        float yPosition = currentSegment.position.y + currentSegment.localScale.y / (2f * _multiplierSizeBlock) +
                          _block.transform.localScale.y / (2f * _multiplierSizeBlock);
        return new Vector3(_buildPoint.position.x, yPosition, _buildPoint.position.z);
    }
}
