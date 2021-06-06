using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    CameraShake CameraShake;
    Player Player;
    private void Start()
    {
        CameraShake = FindObjectOfType<CameraShake>();
        Player = GameObject.Find("Player").GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
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
            gameObject.SetActive(false);
            Invoke("ReturnBulletSprite", 1f);
        }

        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }

    }

    void ReturnPlayerSprite()
    {
        Player.SpriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void ReturnBulletSprite()
    {
        Destroy(gameObject);
    }

}
