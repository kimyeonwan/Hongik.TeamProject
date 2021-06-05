using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //UI �г� �����
    public GameObject panel;
    private float destroyTime = 2.0f;

    //Enemy �ڵ� ����
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;
    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //�г� ����
        Destroy(panel.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3.0f);
            curSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 2);
        int ranPoint = Random.Range(0, 4);

        GameObject enemy = Instantiate(enemyObjs[ranEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);

        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
    }
}
