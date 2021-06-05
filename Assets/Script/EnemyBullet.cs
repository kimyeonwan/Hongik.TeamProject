using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            if (player.Hp > 0)
            {
                player.Hp -= 10;
                player.Hpslider.value -= 0.1f;
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }

    }

}
