using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject EnemieBlockPrefab;
    public float DistanceBetweenSpawns;
    private GameObject _prevBlock;

    public List<float> BlockSpawnOffsets;
    
    public void Update()
    {
        if (Player.IsPlaying)
        {
            if (_prevBlock != null)
            {
                Debug.Log(_prevBlock.transform.position.ToString());
                if (Vector3.Distance(_prevBlock.transform.position, transform.position) >= DistanceBetweenSpawns)
                {
                    SpawnEnemieBlock();
                }
            }
            else
            {
                SpawnEnemieBlock();
            }
        }
    }
    /*
     * Spawn/Creates a block at the spawn position
     * a height offset is added to the spawned block
     */
    private void SpawnEnemieBlock()
    {
        float tempVerticalOffset = 0;
        if (BlockSpawnOffsets.Count != 0)
        {
            tempVerticalOffset = BlockSpawnOffsets[Random.Range(0, BlockSpawnOffsets.Count)];
        }
        
        _prevBlock = Instantiate(EnemieBlockPrefab, transform.position + tempVerticalOffset * Vector3.up, Quaternion.identity);
    }
}
