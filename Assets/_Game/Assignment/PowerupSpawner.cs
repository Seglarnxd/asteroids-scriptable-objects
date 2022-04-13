using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject speedBoostPrefab;
    [SerializeField] private GameObject speedSlowPrefab;
    
    private int interval = 5;
    private Vector3 minBorder;
    private Vector3 maxBorder;

    private void Awake()
    {
        minBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, -10));
        maxBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, -10));
        StartCoroutine(spawnRoutine());
    } 

    private IEnumerator spawnRoutine()
    {
        while (true)
        {
            Vector3 randomPosition = new Vector3(Random.Range(minBorder.x, maxBorder.x), Random.Range(minBorder.y, maxBorder.y));
            // 50/50 chance of spawning boost/slow powerup
            Instantiate(Random.Range(0, 100) <= 50? speedBoostPrefab:speedSlowPrefab, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }   
    }
}
