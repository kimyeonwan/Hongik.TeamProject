using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    Rigidbody2D itemrigid;
    public float speed;
    public string itemName;
    
    Gun_Shooting gun_Shooting;
    Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        itemrigid = GetComponent<Rigidbody2D>();
        itemrigid.velocity = Vector2.down *speed;
        gun_Shooting = FindObjectOfType<Gun_Shooting>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            if(itemName=="Coin")
            {
                player.Hpslider.value += 0.1f;
            }
            if(itemName== "Grenade")
            {
                if(gun_Shooting.Grenade_num<5)
                    gun_Shooting.Grenade_num++;
            }
            if(itemName == "HP")
            {
                player.Hpslider.value += 0.5f;
            }
            Destroy(gameObject);
        }
    }

}
