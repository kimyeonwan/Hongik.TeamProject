using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public float speed;
    public int health;
    //public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D Enemyrigid;

    public GameObject Hit_Fx;

    public GameObject player;
    public GameObject Enemybullet;

    public float maxShotDelay;
    public float curShotDelay;

    Game_Manager Game_Manager;
    CameraShake CameraShake;
    Player Player;

    public AudioSource AudioSource;
    public AudioClip bulletSound;
    public AudioClip reloadSound;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Enemyrigid = GetComponent<Rigidbody2D>();
        
        Enemyrigid.velocity = Vector2.left * speed;
        
        maxShotDelay = 2.0f;

        CameraShake = FindObjectOfType<CameraShake>();

        Player = GameObject.Find("Player").GetComponent<Player>();
        Game_Manager = FindObjectOfType<Game_Manager>();

        AudioSource = gameObject.AddComponent<AudioSource>();
        AudioSource.loop = false;
        AudioSource.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
        Reload();
    }

    void OnHit(int dmg)
    {
        health -= dmg;

        //spriteRenderer.sprite = sprites[1];
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        Invoke("ReturnSprite", 0.3f);

        if (health <= 0 && (enemyName == "Enemy1" || enemyName == "Enemy2" || enemyName == "Enemy3"))
        {
            Instantiate(Hit_Fx, transform.position, transform.rotation);
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            spriteRenderer.flipY = true;
            Enemyrigid.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            Game_Manager.enemyDeadnum += 1;
            Destroy(gameObject, 0.5f);
        }
        if (health <= 0 && enemyName == "Enemy_Boss")
        {
            Instantiate(Hit_Fx, transform.position, transform.rotation);
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            spriteRenderer.flipY = true;
            Enemyrigid.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            Game_Manager.enemyDeadnum = 0;
            Game_Manager.isBoss = false;
            Destroy(gameObject, 0.5f);
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void ReturnPlayerSprite()
    {
        Player.SpriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            if(enemyName == "Enemy_Boss")
            {
                Game_Manager.enemyDeadnum = 0;
                Game_Manager.isBoss = false;
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PlayerBullet")
        {
            //Instantiate(Hit_Fx, transform.position, transform.rotation);
            Gun_Manager currentGun = Gun_Shooting.instance.GetGun();
            OnHit(currentGun.Gun_Dmg);
            //Destroy(gameObject);
        }
        if(collision.gameObject.tag=="Boom")
        {
            OnHit(25);
        }
        if (collision.gameObject.tag == "Player")
        {
            
            if (Player.Hp > 0)
            {
                Player.Hp -= 10;
                Player.Hpslider.value -= 0.1f;
                CameraShake.shake = 0.3f;
            }
            Player.SpriteRenderer.color = new Color(1, 1, 1, 0.4f);
            Invoke("ReturnPlayerSprite", 0.3f);
        }
    }

    void FireBullet()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player.Hp > 0)
        {
            if (curShotDelay < maxShotDelay)
                return;
            if(enemyName =="Enemy1"|| enemyName == "Enemy2" || enemyName == "Enemy3")
            {
                Vector3 dirVec = player.transform.position - transform.position;
                GameObject bullet = Instantiate(Enemybullet, transform.position, transform.rotation);


                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();

                rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

                curShotDelay = 0;
                //
                AudioSource.clip = bulletSound;
                AudioSource.Play();
                if(!AudioSource.isPlaying)
                {
                    AudioSource.clip = reloadSound;
                    AudioSource.Play();
                }
            }
            else if(enemyName == "Enemy_Boss")
            {
                Vector3 dirVec = player.transform.position - (transform.position + Vector3.up * 2.4f + Vector3.left * 2.4f);
                GameObject bulletLL = Instantiate(Enemybullet, transform.position + Vector3.up * 2.4f + Vector3.left * 2.4f, transform.rotation);
                Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                rigidLL.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

                dirVec = player.transform.position - (transform.position + Vector3.up * 2.1f + Vector3.left * 2.1f);
                GameObject bulletLM = Instantiate(Enemybullet, transform.position + Vector3.up * 2.1f + Vector3.left * 2.1f, transform.rotation);
                Rigidbody2D rigidLM = bulletLM.GetComponent<Rigidbody2D>();
                rigidLM.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

                dirVec = player.transform.position - (transform.position + Vector3.up * 1.8f + Vector3.left * 1.84f);
                GameObject bulletLR = Instantiate(Enemybullet, transform.position + Vector3.up * 1.8f + Vector3.left * 1.8f, transform.rotation);
                Rigidbody2D rigidLR = bulletLR.GetComponent<Rigidbody2D>();
                rigidLR.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

                dirVec = player.transform.position - (transform.position + Vector3.down * 1.8f + Vector3.right * 1.8f);
                GameObject bulletRL = Instantiate(Enemybullet, transform.position+ Vector3.down * 1.8f + Vector3.right * 1.8f, transform.rotation);
                Rigidbody2D rigidRL = bulletRL.GetComponent<Rigidbody2D>();
                rigidRL.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

                dirVec = player.transform.position - (transform.position + Vector3.down * 2.1f + Vector3.right * 2.1f);
                GameObject bulletRM = Instantiate(Enemybullet, transform.position + Vector3.down * 2.1f + Vector3.right * 2.1f, transform.rotation);
                Rigidbody2D rigidRM = bulletRM.GetComponent<Rigidbody2D>();
                rigidRM.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);


                dirVec = player.transform.position - (transform.position + Vector3.down * 2.4f + Vector3.right * 2.4f);
                GameObject bulletRR = Instantiate(Enemybullet, transform.position + Vector3.down * 2.4f + Vector3.right * 2.4f, transform.rotation);
                Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                rigidRR.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);


                dirVec = player.transform.position - (transform.position + Vector3.up * 0.9f + Vector3.left * 0.9f);
                GameObject bulletL = Instantiate(Enemybullet, transform.position + Vector3.up * 0.9f + Vector3.left * 0.9f, transform.rotation);
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                rigidL.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

                dirVec = player.transform.position - (transform.position + Vector3.down * 0.9f + Vector3.right * 0.9f);
                GameObject bulletR = Instantiate(Enemybullet, transform.position + Vector3.down * 0.9f + Vector3.right * 0.9f, transform.rotation);
                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                rigidR.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

                curShotDelay = 0;
                //
                AudioSource.clip = bulletSound;
                AudioSource.Play();
                if (!AudioSource.isPlaying)
                {
                    AudioSource.clip = reloadSound;
                    AudioSource.Play();
                }
            }
            
        }
    }
    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}
