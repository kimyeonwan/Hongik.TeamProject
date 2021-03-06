using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public Game_Manager instance;
    //UI 패널 지우기
    public GameObject panel;
    private float destroyTime = 2.0f;

    //Enemy 자동 생성
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;
    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject Textmesh;

    public GameObject player;


    public int enemyDeadnum;
    public bool isBoss;


    public AudioSource audioSource;
    public AudioClip BGMSound;

    // Start is called before the first frame update
    void Start()
    {
        //패널 삭제
        Destroy(panel.gameObject, destroyTime);
        enemyDeadnum = 0;
        isBoss = false;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = 0.3f;
        Textmesh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay && !isBoss)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3.0f);
            curSpawnDelay = 0;
        }
        if(audioSource.isPlaying==false)
        {
            audioSource.clip = BGMSound;
            audioSource.Play();
        }
        if(enemyDeadnum>8&&isBoss==false)
        {
            Textmesh.SetActive(true);
        }
        if(isBoss==true)
        {
            Textmesh.SetActive(false);
        }
    }

    void SpawnEnemy()
    {
        if(enemyDeadnum < 10)
        {
            int ranEnemy = Random.Range(0, 3);
            int ranPoint = Random.Range(0, 5);

            GameObject enemy = Instantiate(enemyObjs[ranEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);

            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
        }
        else
        {
            isBoss = true;
            GameObject enemy = Instantiate(enemyObjs[3], spawnPoints[2].position, spawnPoints[2].rotation);
            
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
        }
    }
}
