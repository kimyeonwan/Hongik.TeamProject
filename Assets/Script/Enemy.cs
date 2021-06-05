using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Enemyrigid = GetComponent<Rigidbody2D>();
        Enemyrigid.velocity = Vector2.left * speed;

        maxShotDelay = 2.0f;
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

        if (health <= 0)
        {
            Instantiate(Hit_Fx, transform.position, transform.rotation);
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            spriteRenderer.flipY = true;
            Enemyrigid.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            Destroy(gameObject, 0.5f);
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PlayerBullet")
        {
            //Instantiate(Hit_Fx, transform.position, transform.rotation);
            Bullet bullet = GameObject.Find("Bullet(Clone)").GetComponent<Bullet>();
            OnHit(bullet.dmg);
            //Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            if (player.Hp > 0)
            {
                player.Hp -= 10;
                player.Hpslider.value -= 0.1f;
            }
        }
    }

    void FireBullet()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player.Hp > 0)
        {
            if (curShotDelay < maxShotDelay)
                return;
            Vector3 dirVec = player.transform.position - transform.position;
            GameObject bullet = Instantiate(Enemybullet, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();

            rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

            curShotDelay = 0;
        }
    }
    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}
