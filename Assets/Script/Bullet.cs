using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg;
    public float speed;
    Rigidbody2D rigid;

    public GameObject hit;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag =="Enemy")
        {
            Instantiate(hit, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
