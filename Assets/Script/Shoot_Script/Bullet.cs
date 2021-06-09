using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;
    Rigidbody2D Bullet_Rigid;
    public float Speed = 10f;
    public GameObject Fx;

    private void OnEnable()
    {
        if (Bullet_Rigid == null)
            Bullet_Rigid = GetComponent<Rigidbody2D>();
        Bullet_Rigid.velocity = Vector3.zero;
        Bullet_Rigid.velocity = Gun_Shooting.instance.GunTip.right * Speed;
        StartCoroutine(DestroyBullet());
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Gun_Shooting.instance.InsertQueue(gameObject);
            Instantiate(Fx, transform.position, transform.rotation);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(2f);
        Gun_Shooting.instance.InsertQueue(gameObject);
    }
}
