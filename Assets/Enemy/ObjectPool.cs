using System;
using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefap;
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] int poolSize = 5;

    private GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void Start()
    {

        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefap, transform);
            pool[i].SetActive(false);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }

    }

}
