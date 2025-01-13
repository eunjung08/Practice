using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Transform> enemyResponse = new List<Transform>();
    public GameObject prefabEnemy;
    List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Response");

        foreach(GameObject obj in objs)
        {
            enemyResponse.Add(obj.transform);
        }
        CreateEnemy();
    }

    public void CreateEnemy()
    {
        foreach (Transform tr in enemyResponse)
        {
            Instantiate(prefabEnemy, tr.position, prefabEnemy.transform.rotation);
        }
    }
}
