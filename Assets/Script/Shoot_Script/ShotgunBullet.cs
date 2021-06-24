using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{

    Rigidbody2D Bullet_Rigid;
    public float Speed = 10f;
    public GameObject Fx;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Bullet_Rigid == null)
            Bullet_Rigid = GetComponent<Rigidbody2D>();
        Bullet_Rigid.velocity = Vector3.zero;
        Bullet_Rigid.velocity = Gun_Shooting.instance.GunTip.right * Speed;
        StartCoroutine(DestroyBullet());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(Fx, transform.position, transform.rotation);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
