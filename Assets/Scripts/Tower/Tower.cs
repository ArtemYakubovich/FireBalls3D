using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;

    private List<Block> _blocks;

    private float _multiplierBlockScale;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach (Block block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
    }

    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit;
        _blocks.Remove(hitedBlock);

        foreach (Block block in _blocks)
        {
            float yPosition = block.transform.position.y - block.transform.localScale.y * 0.1f;
            block.transform.position = new Vector3(block.transform.position.x, yPosition, block.transform.position.z);
        }
    }
}
