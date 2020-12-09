using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Singleton
    public static Spawner Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public GameObject[] enemyPrefabs;

    WaitForSeconds waitTime = new WaitForSeconds(7f);

    public void OnSpawnEnemy()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < GameManager.Instance.stage * 2; ++i)
            {
                Debug.Log(i);
                if (i % 3 == 0)
                {
                    Instantiate(enemyPrefabs[1], transform.position, Quaternion.identity);
                }
                else if (i % 5 == 0)
                {
                    Instantiate(enemyPrefabs[2], transform.position, Quaternion.identity);
                }
                else if(i%2 == 0)
                {
                    Instantiate(enemyPrefabs[0], transform.position, Quaternion.identity);
                }
                yield return waitTime;
            }
            break;
        }
    }
}
